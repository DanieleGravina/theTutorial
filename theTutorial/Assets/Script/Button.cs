using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	public MenuState myState;
	
	const float DELTA_SCALE = 1.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player" && myState == MenuState.EXIT){
			Application.LoadLevel("BlueScreen_Level");
		}
	}
	
	/*void OnTriggerExit(Collider other){
		
		if(other.tag == "Player"){
			transform.parent.transform.localScale -= new Vector3(DELTA_SCALE, DELTA_SCALE, DELTA_SCALE);
		}
	}*/
}
