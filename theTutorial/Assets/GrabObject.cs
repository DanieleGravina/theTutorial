using UnityEngine;
using System.Collections;

public class GrabObject : MonoBehaviour {
	
	GameObject target;
	
	RaycastHit hit;

	float correctionforce = 50.0f;
	
	bool grabbed = false;
	
	GameObject grabbedObject;

	// Use this for initialization
	void Start () {
		
		target = GameObject.Find("Beacon");
	
	}
	
	// Update is called once per frame
	void Update () {
    

	    if(Input.GetButton("Fire1") && grabbed)
	
	    {
	
		    grabbed = false;
		    
		    grabbedObject.rigidbody.freezeRotation = false;
			grabbedObject.rigidbody.useGravity = true;
	
	    }
    
	    if(Input.GetKey("e") && !grabbed){
	    	
	    	if(Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.tag == "Key"){
	    		grabbed = true;
	    		grabbedObject = hit.collider.gameObject;
				
				if(grabbedObject.rigidbody.freezeRotation == false)
				{
	
	   	 			grabbedObject.rigidbody.freezeRotation = true;
	
	   	 		}
				
			    if(grabbedObject.rigidbody.useGravity == true)
			    {
			 
		          grabbedObject.rigidbody.useGravity = false;
			 
			    }
	    		
	    	}
	    }

    if(grabbed){
		
		Vector3 force = target.transform.position - grabbedObject.transform.position;
			
	    grabbedObject.rigidbody.velocity = force.normalized * grabbedObject.rigidbody.velocity.magnitude;
	
	 
	
	    grabbedObject.rigidbody.AddForce(force * correctionforce);
	
	    
	
	    grabbedObject.rigidbody.velocity *= Mathf.Min(1.0f, force.magnitude / 2);
		}

    }
	
}
