using UnityEngine;
using System.Collections;

public class Cake : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			other.gameObject.GetComponent<Player>().OnRange(transform.gameObject);
		}
	}
}
