using UnityEngine;
using System.Collections;

public enum buttons{
	UP,
	RIGHT,
	LEFT,
	DOWN
	
}

public class HUDPosition : MonoBehaviour {
	
	public GameObject hud;
	
	public GameObject room;
	
	Transform manager;
	
	public buttons typeButton;
	
	public int ID;
	
	private bool onButton = false;
	
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
		manager = transform.parent.transform.parent.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(onButton){
			timer += 1*Time.deltaTime;
			
			if (timer >= 10f){
				onButton = false;
				timer = 0.0f;
			}
		}
	
	}
	
	void OnTriggerEnter(Collider other){
		
		if(!onButton && other.tag == "Player"){
			
			//this.transform.parent.GetComponent<MeshRenderer>().material.color = Color.red;
			
			onButton = true;
			
			manager.gameObject.GetComponent<Manager>().MovePlatform(ID, typeButton, hud, room, transform.parent.gameObject, collider);
			
		}
		
	}
}
