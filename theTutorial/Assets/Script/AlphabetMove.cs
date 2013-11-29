using UnityEngine;
using System.Collections;

public enum states {
	ROTATION,
	TRANSLATION
}

public class AlphabetMove : MonoBehaviour {

	public int velocity = 10;
	
	float translation;
	
	float deltaTime;
	
	Vector3 initial_pos;
	
	Vector3 midpoint;
	
	Vector3 axes = new Vector3(0, 0, 1);
	
	int angle;
	
	states myState = states.TRANSLATION; 
	
	// Use this for initialization
	void Start () {
		initial_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		deltaTime = Time.deltaTime;
		
		if( transform.position.x <= -22.18954f && myState == states.TRANSLATION){
			
			midpoint = new Vector3(-22.18954f, 11.32259f, -152.3448f);
			myState = states.ROTATION;
			angle = 179;
			
		}else if( transform.position.x >= 184.3105 && myState == states.TRANSLATION) {
			
			midpoint = new Vector3(184.3105f, 11.32259f, -152.3448f);
			myState = states.ROTATION;
			
			angle = 359;
			
		}
		
		if(myState == states.ROTATION ){
			
			transform.RotateAround(midpoint, axes, velocity * deltaTime * 3.14f);
			
			if(transform.rotation.eulerAngles.z >= angle){
				myState = states.TRANSLATION;
				float angles = transform.rotation.eulerAngles.z - (angle+1);
				transform.Rotate(new Vector3(0, 0, -angles));
				Debug.Log(transform.rotation.eulerAngles.z);
			}
			
		}else {
			translation = deltaTime * velocity;
	        transform.Translate(-translation, 0, 0);
		}
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Debug.Log("touch");
			other.transform.position.Set(transform.position.x, 0, 0);
		}
	}
	
}
