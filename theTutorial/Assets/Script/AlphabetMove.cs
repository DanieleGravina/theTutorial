using UnityEngine;
using System.Collections;

public enum states {
	ROTATION,
	TRANSLATION
}

public class AlphabetMove : MonoBehaviour {

	public int velocity = 10;
	
	int targetAngle = 0;
	
	int angle;
	
	states myState = states.TRANSLATION; 
	
	float translation;
	
	float deltaTime;
	
	Vector3 initial_pos;
	
	Vector3 position;
	
	Vector3 midPoint;
	
	Vector3 axes = new Vector3(0, 0, 1);
	
	Vector3 initial_midPoint = new Vector3(177.6943f, 11.32259f, -152.3448f);
	
	Vector3 final_midPoint = new Vector3(-14.06157f, 11.32259f, -152.3448f);
	
	Vector3 tmp;
	
	
	// Use this for initialization
	void Start () {
		initial_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		deltaTime = Time.deltaTime;
		
		if( transform.position.x <= final_midPoint.x && myState == states.TRANSLATION){
			
			midPoint = final_midPoint;
			myState = states.ROTATION;
			angle = 179;
			targetAngle = 180;
			
			
		}else if( transform.position.x >= initial_midPoint.x && transform.position.y <= 11f && myState == states.TRANSLATION) {
			
			midPoint = initial_midPoint;
			myState = states.ROTATION;
			
			angle = 345;
			targetAngle = 0;
			position = initial_pos;
			
			
		}
		
		if(myState == states.ROTATION ){
			
			transform.RotateAround(midPoint, axes, velocity * deltaTime * 3.14f);
			
			if(transform.rotation.eulerAngles.z >= angle){
				myState = states.TRANSLATION;
				tmp = transform.eulerAngles;
				tmp.z = targetAngle;
				transform.eulerAngles = tmp;
				
				if(angle == 340)
					transform.position = position;
			}
			
		}else {
			translation = deltaTime * velocity;
	        transform.Translate(-translation, 0, 0);
		}
	
	}
	
	/*void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player"){
			other.attachedRigidbody.AddForce(new Vector3(-10, 0, 0));
		}
	}*/
	
	void OnTriggerEnter (Collider other)
	{
	    if (other.tag == "Player")
	    {
	       other.transform.parent = this.transform;
	    }
	}
 
	void OnTriggerExit (Collider other)
	{
	    if (other.tag == "Player")
	    {
	       other.transform.parent = null;
	    }
	}
}
