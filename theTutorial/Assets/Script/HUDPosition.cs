using UnityEngine;
using System.Collections;

public enum buttons{
	UP,
	RIGHT,
	LEFT,
	DOWN,
	NULL
	
}

public class HUDPosition : MonoBehaviour {
	
	public GameObject hud;
	
	public GameObject room;
	
	Transform manager;
	
	public int ID;
	
	private bool onButton = false;
	
	bool pressArrow = false;
	
	buttons typeButton = buttons.NULL;

	// Use this for initialization
	void Start () {
		
		manager = transform.parent.transform.parent.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(onButton){
		
			if(Input.GetKeyUp("i"))
				typeButton = buttons.UP;
				
			if(Input.GetKeyUp("k"))
				typeButton = buttons.DOWN;
			
			if(Input.GetKeyUp("l"))
				typeButton = buttons.RIGHT;
			
			if(Input.GetKeyUp("j"))
				typeButton = buttons.LEFT;	
			
			if(typeButton != buttons.NULL){
				manager.gameObject.GetComponent<Manager>().MovePlatform(ID, typeButton, hud, room, transform.parent.gameObject, collider);
				typeButton = buttons.NULL;
			}
		}
		
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player"){
			
			onButton = true;
			
			other.transform.parent = this.transform;
			
			manager.gameObject.GetComponent<Manager>().MovePlatform(ID, typeButton, hud, room, transform.parent.gameObject, collider);
			
		}
		
	}
		
	void OnTriggerExit(Collider other){
			
		if(other.tag == "Player"){
				
				onButton = false;
			
				other.transform.parent = null;
		}
	}
			
}
