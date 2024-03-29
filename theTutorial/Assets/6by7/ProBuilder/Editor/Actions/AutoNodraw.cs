using UnityEngine;
using UnityEditor;
using System.Collections;

public class AutoNodraw : EditorWindow {

	const float COLLISION_DISTANCE = .02f;
	float userSetCollisionDistance = .02f;
	public static Material nodrawMat;
	pb_Editor editorRef;

	[MenuItem("Window/ProBuilder/Actions/Auto Nodraw Tool")]
	public static void AutoNodrawWindow()
	{
		EditorWindow.GetWindow(typeof(AutoNodraw), true, "NoDraw Tool");
	}

	public void OnEnable()
	{
		editorRef = pb_Editor.editorInstance;
	}

	bool autoUpate = true;
	public void OnGUI()
	{
		userSetCollisionDistance = EditorGUILayout.Slider("Collsion Distance Check", userSetCollisionDistance, .001f, 1f);
		if(userSetCollisionDistance < .0001)
			userSetCollisionDistance = .0001f;

		autoUpate = EditorGUILayout.Toggle("Auto Update Selection", autoUpate);

		if(autoUpate && GUI.changed)
			SelectHiddenFaces(editorRef, userSetCollisionDistance);

		if(GUILayout.Button("Apply NoDraw"))
		{
			pb_Texture_Editor.ApplyNoDraw(editorRef.selection, pb_Editor.show_NoDraw);
			editorRef.ClearFaceSelection();
		}
	}

	[MenuItem("Window/ProBuilder/Actions/Select Hidden Faces")]
	public static void FindHiddenFaces()
	{
		SelectHiddenFaces(pb_Editor.editorInstance, COLLISION_DISTANCE);
	}

	public static void SelectHiddenFaces(pb_Editor editor, float collision_distance)
	{
		// Open the pb_Editor window if it isn't already open.
		// pb_Editor editor = pb_Editor.editorInstance;

		// Clear out all selected
		editor.ClearSelection();

		// If we're in Mode based editing, make sure that we're also in geo mode. 
		editor.SetEditLevel(pb_Editor.EditLevel.Geometry);

		// aaand also set to face seelction mode
		editor.SetSelectionMode(ProBuilder.SelectMode.Face);

		// Find all ProBuilder objects in the scene.
		pb_Object[] pbs = (pb_Object[])Object.FindObjectsOfType(typeof(pb_Object));

		// Cycle through every quad
		foreach(pb_Object pb in pbs)
		{
			// Ignore if it isn't a detail or occluder
			if(pb.entityType != ProBuilder.EntityType.Detail && pb.entityType != ProBuilder.EntityType.Occluder)
				continue;	

			bool addToSelection = false;

			foreach(pb_Face q in pb.faces)
			{
				if(HiddenFace(pb, q, collision_distance))
				{
					// If a hidden face is found, set material to NoDraw
					// pb.SetQuadMaterial(q, nodrawMat);

					// Mark this object to be added to selection
					addToSelection = true;

					// Add hit face to selected_faces
					editor.AddToFaceSelection(pb, q);
				}

			}

			if(addToSelection)
				editor.AddToSelection(pb.gameObject);
		}
		editor.UpdateSelection();
		
		// if(editor.selection.Length > 0) {
			editor.SetSelectionMaterial(true);
		// }
	}

	public static bool HiddenFace(pb_Object pb, pb_Face q, float dist)
	{
		// Grab the face normal
		Vector3 dir = pbUtil.PlaneNormal(pb.VerticesInWorldSpace(q));

		// If casting from the center of the plane hits, chekc the rest of the points for collisions
		Vector3 orig = pb.FaceCenter(q);

		bool hidden = true;
		Transform hitObj = RaycastFaceCheck(orig, dir, dist, null);
		if(hitObj != null)
		{
			Vector3[] v = pb.VerticesInWorldSpace(q.indices);
			for(int i = 0; i < v.Length; i++)
			{
				if(null == RaycastFaceCheck(v[i], dir, dist, hitObj))
				{
					hidden = false;
					break;
				}
			}
		}
		else
			hidden = false;

		return hidden;
	}

	public static Transform RaycastFaceCheck(Vector3 origin, Vector3 dir, float dist, Transform targetTransform)
	{
		RaycastHit hit;
		if(Physics.Raycast(origin, dir, out hit, dist)) {
			// We've hit something.  Now check to see if it is a ProBuilder object,
			// and if so, make sure it's a visblocking brush.

			// if targetTransform isn't null, make sure that the hit object matches 
			if(targetTransform != null)
			{
				if(hit.transform != targetTransform)
					return null;
			}

			pb_Entity ent = hit.transform.GetComponent<pb_Entity>();
			if(ent != null)
			{
				if(ent.entityType == ProBuilder.EntityType.Detail || ent.entityType == ProBuilder.EntityType.Occluder)
					return hit.transform;		// it's a brush, blocks vision, return true
				else
					return null;		// not a vis blocking brush
			}
		}

		// It ain't a ProBuilder object of the entity type Brush or Occluder (world brush)
		return null;
	}
}
