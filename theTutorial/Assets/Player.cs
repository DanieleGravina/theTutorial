using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	bool initialized = false;
	
	GameObject Arrow;
	
	MouseLook mouseLook;
	
	RigidbodyFPSController controller;

	// Use this for initialization
	void Start () {
		
		Arrow = GameObject.Find("Arrow");
		
		Screen.showCursor = false;
		
		mouseLook = GetComponent<MouseLook>();
		controller = GetComponent<RigidbodyFPSController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!initialized){
			if(Arrow.renderer.enabled == true)
				Arrow.transform.GetChild(0).renderer.enabled = false;
				Arrow.renderer.enabled = false;
			
			initialized = true;
		}
			
	}
	
	public void BlockPlayer(){
		
		rigidbody.constraints = RigidbodyConstraints.FreezePosition;
		controller.enabled = false;
		
	}
	
	public void FreePlayer() {
		
		rigidbody.constraints = RigidbodyConstraints.None;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		controller.enabled = true;
		
	}
		
}
