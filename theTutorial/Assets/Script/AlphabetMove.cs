using UnityEngine;
using System.Collections;

public enum states {
	ROTATION,
	TRANSLATION
}

public class AlphabetMove : MonoBehaviour {

	public int velocity = 10;
	
	int angles = 0;
	
	float translation;
	
	float deltaTime;
	
	Vector3 initial_pos;
	
	Vector3 position;
	
	Vector3 midpoint;
	
	Vector3 axes = new Vector3(0, 0, 1);
	
	int angle;
	
	public states myState = states.TRANSLATION; 
	
	// Use this for initialization
	void Start () {
		initial_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		deltaTime = Time.deltaTime;
		
		if( transform.position.x <= -22.18954f && myState == states.TRANSLATION){
			
			//Debug.Log("begin rotation1: position" + transform.position + "angle" + transform.eulerAngles.z + " state"+ myState);
			midpoint = new Vector3(-22.18954f, 11.32259f, -152.3448f);
			myState = states.ROTATION;
			angle = 179;
			angles = 180;
			
			
		}else if( transform.position.x >= 183.6f && transform.position.y <= 11f && myState == states.TRANSLATION) {
			
			Debug.Log("begin rotation2: position" + transform.position + "angle" + transform.eulerAngles.z + " state"+ myState);
			midpoint = new Vector3(184.3105f, 11.32259f, -152.3448f);
			myState = states.ROTATION;
			
			angle = 340;
			angles = 0;
			position = initial_pos;
			
			
		}
		
		if(myState == states.ROTATION ){
			
			Debug.Log("rotating: position" + transform.position + "angle" + transform.eulerAngles.z + " state"+ myState);
			transform.RotateAround(midpoint, axes, velocity * deltaTime * 3.14f);
			
			if(transform.rotation.eulerAngles.z >= angle){
				myState = states.TRANSLATION;
				Vector3 tmp = transform.eulerAngles;
				tmp.z = angles;
				transform.eulerAngles = tmp;
				
				if(angle == 340)
					transform.position = position;
			}
			
		}else {
			Debug.Log("translation: position" + transform.position + "angle" + transform.eulerAngles.z + " state"+ myState);
			translation = deltaTime * velocity;
	        transform.Translate(-translation, 0, 0);
		}
	
	}
	
	void OnTriggerEnter (Collider other)
	{
	    if (other.tag == "Player")
	    {
	       other.transform.parent = transform;
	    }
	}
 
	void OnTriggerExit (Collider other)
	{
		Debug.LogError("Exit");
	    if (other.tag == "Player")
	    {
	       other.transform.parent = null;
	    }
	}
}
