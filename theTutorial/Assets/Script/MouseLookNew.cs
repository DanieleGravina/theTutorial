using UnityEngine;
using System.Collections;

public class MouseLookNew : MonoBehaviour {
	
	public float sensibility;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate( new Vector3(0,Input.GetAxis("Mouse X")*sensibility,0), Space.World);
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y")*sensibility,0,0));
	
	}
}
