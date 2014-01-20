using UnityEngine;
using System.Collections;

public class EnterMapDoor : MonoBehaviour {

	bool afterTrigger = false;
	GameObject rigidbodyController;

	public string[] text;
	public GameObject map;
	
	GameObject GUIdialog;
	public GameObject doorTrigger;

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
			PlatformMovement.enable = true;
			this.enabled = false;
			doorTrigger.SetActive(false);
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
			rigidbodyController.transform.parent = this.transform.parent.transform;
			map.SetActive(true);


		}
	}
}
