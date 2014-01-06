using UnityEngine;
using System.Collections;

public class RayCollider : MonoBehaviour {
	
    CapsuleCollider capsule;
	
	public float LineWidth; // use the same as you set in the line renderer.

	// Use this for initialization
	void Start () {
       capsule = GetComponent<CapsuleCollider>();
       capsule.radius = LineWidth / 2;
       capsule.center = Vector3.zero;
       capsule.direction = 2; // Z-axis for easier "LookAt" orientation
	}
	
	public void setPosition(Vector3 start, Vector3 end){
	   capsule.transform.position = start + (end - start) / 2;
       capsule.transform.LookAt(start);
       capsule.height = (end - start).magnitude;
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Debug.Log ("touch player");
			//life--
		}
	}
}
