using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	bool initialized = false;
	
	GameObject Arrow;

	// Use this for initialization
	void Start () {
		
		Arrow = GameObject.Find("Arrow");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!initialized){
			if(Arrow.renderer.enabled == true)
				Arrow.renderer.enabled = false;
			
			initialized = true;
		}
			
	}
		
}
