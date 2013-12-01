using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	public MenuState myState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		
		//problem if parent destroy this object during the call ??
		if(other.tag == "Player"){
			transform.parent.transform.parent.GetComponent<MenuGame>().ChangeState(myState);
		}
	}
}
