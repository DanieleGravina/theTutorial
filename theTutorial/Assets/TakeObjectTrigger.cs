using UnityEngine;
using System.Collections;

public class TakeObjectTrigger : MonoBehaviour {

	public string[] text;
	
	bool afterTrigger = false;
	
	public GameObject GUIdialog;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player" && !afterTrigger){
			afterTrigger = true;
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
		}
	}
}
