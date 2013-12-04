using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	GameObject objectOnRange;
	
	//tells if the player is in the range of a object he can take
	bool isOnRange = false;
	
	bool hasObject = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey("f") && isOnRange){
			objectOnRange.transform.parent = transform;
			hasObject = true;
		}
		
		if(Input.GetKey("g") && hasObject){
			hasObject = false;
			objectOnRange.transform.parent = null;
		}
	
	}
	
	//called by the object when player approach the object
	public void OnRange(GameObject other){
		isOnRange = true;
		objectOnRange = other;
	}
		
}
