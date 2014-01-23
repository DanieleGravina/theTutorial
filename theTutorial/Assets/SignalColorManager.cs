using UnityEngine;
using System.Collections;

public class SignalColorManager : MonoBehaviour {
	
	bool isOpen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ChangeSignalColor(){
		//if(isOpen){
		//	renderer.material.color = Color.red;
		//	transform.GetChild (0).light.color = Color.red;
		//	isOpen = false;
		//}
		//else{
			renderer.material.color = Color.green;
			transform.GetChild (0).light.color = Color.green;
			isOpen = true;
		//}
	}
}
