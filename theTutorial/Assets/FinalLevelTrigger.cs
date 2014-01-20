using UnityEngine;
using System.Collections;

public class FinalLevelTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Application.LoadLevel("InitialMenu");
		}
	}
}
