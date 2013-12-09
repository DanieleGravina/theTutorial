using UnityEngine;
using System.Collections;

public class NoGravity : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other){
		
		if(other.tag == "Key")
			other.rigidbody.AddForce(Vector3.up * 11f, ForceMode.Acceleration);
		
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Key" && Globals.numInventory < 3)
			Globals.numInventory++;
			other.rigidbody.freezeRotation = true;
	}
}
