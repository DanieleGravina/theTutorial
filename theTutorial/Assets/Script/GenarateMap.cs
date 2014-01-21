using UnityEngine;
using System.Collections;

public class GenarateMap : MonoBehaviour {
	
	public enum sd{
		pixels, screen_percent
	};
	
	public enum ha{
		left, center, right
	};
	
	public enum va{
		top, middle, bottom
	};
	
	public Transform target;
	public Texture2D marker;
	
	public float camHeight = 1.0f;
	public float camDistance = 2.0f;
	
	public bool freezeRotation = true;
	
	public sd dimensionIn = sd.pixels;
	
	public ha horizontalAlignment = ha.left;
	public va verticalAlignment = va.top;
	
	public int width = 50;
	public int height = 50;
	
	public float xOffset = 0.0f;
	public float yOffset = 0.0f;
	
	public int angleX = 90;
	
	
	// Use this for initialization
	void Start () {
	
		Vector3 angles = transform.eulerAngles;
		angles.x = angleX;
		angles.y = target.transform.eulerAngles.y;
		transform.eulerAngles = angles;
		Draw();
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y + camHeight, 
			target.position.z);
		
		camera.orthographicSize = camDistance;
		
		if(freezeRotation){
			Vector3 angles = transform.eulerAngles;
			angles.y = target.transform.eulerAngles.y;
			transform.eulerAngles = angles;
		}
	}
	
	void Draw(){
		
		int hsize = Mathf.RoundToInt(width * 0.01f * Screen.width);
		int vsize = Mathf.RoundToInt(height * 0.01f *Screen.height);
		
		int hLoc = Mathf.RoundToInt(xOffset * 0.01f * Screen.width);
		int vLoc = Mathf.RoundToInt(yOffset * 0.01f * Screen.height);
		
		if(dimensionIn == sd.pixels){
			hsize = height;
			vsize = width;
		}
		
		switch(horizontalAlignment){
			
		case ha.left: 
			hLoc = Mathf.RoundToInt(xOffset * 0.01f * Screen.width);
			break;
			
		case ha.right :
			hLoc = Mathf.RoundToInt((Screen.width - hsize) - (xOffset * 0.01f * Screen.width));
			break;
			
		case ha.center :
			hLoc = Mathf.RoundToInt((Screen.width - 0.05f) - (xOffset * 0.01f * Screen.width));
			break;		
			
		}
		
		switch(verticalAlignment){
			
		case va.top:
			vLoc = Mathf.RoundToInt((Screen.height - vsize) - (yOffset * 0.01f * Screen.height));
			break;
			
		case va.middle :
			vLoc = Mathf.RoundToInt((Screen.height - 0.5f) - (vsize * 0.5f) - (yOffset * 0.01f * Screen.height));
			break;
			
		case va.bottom :
			vLoc = Mathf.RoundToInt(yOffset * 0.01f * Screen.height);
			break;
		}
		
		transform.camera.pixelRect = new Rect(hLoc, vLoc, hsize, vsize);
	}
	
	void onGUI(){
		
		Vector3 markerPos = transform.camera.camera.WorldToViewportPoint(target.position);
		
		int pointX = Mathf.RoundToInt((transform.camera.pixelRect.xMin + transform.camera.pixelRect.xMax) * markerPos.x);
		int pointY = Mathf.RoundToInt((transform.camera.pixelRect.yMin + transform.camera.pixelRect.yMax) * markerPos.y);
		
		GUI.DrawTexture(new Rect(pointX-(marker.width*0.5f), pointY-(marker.height*0.5f), marker.width,marker.height)
			, marker, ScaleMode.StretchToFill, true, 10.0f);
		
	}
}
