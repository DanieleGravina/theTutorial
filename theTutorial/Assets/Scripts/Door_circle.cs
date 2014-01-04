using UnityEngine;
using System.Collections;

public class Door_circle : MonoBehaviour {

	
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.name == "First Person Controller")
        {
            GetComponent<Animation>().Play();
        }
	}
}
