using UnityEngine;
using System.Collections;

public class EnterMapDoor : MonoBehaviour {

	bool afterTrigger = false;
	GameObject rigidbodyController;

	public string[] text;
	public GameObject map;
	
	GameObject GUIdialog;

	// Use this for initialization
	void Start () {
		rigidbodyController = GameObject.FindGameObjectWithTag("Player");
		GUIdialog = GameObject.Find("GUI Text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player" && !afterTrigger){
			afterTrigger = true;
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
			rigidbodyController.transform.parent = this.transform.parent.transform.parent.transform;
			//map.GetComponent<Camera>().enabled = true;
			map.SetActive(true);
			this.GetComponent<DoorTrigger>().enabled = false;


		}
	}
}
