using UnityEngine;
using System.Collections;

public class TimerRoomTrigger : MonoBehaviour {

	public string[] text;
	public GameObject TimerGUI, PhysicalTimer;
	
	bool afterTrigger;
	
	GameObject GUIdialog;

	// Use this for initialization
	void Start () {
		
		GUIdialog = GameObject.Find("GUI Text");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player" && !Globals.CountDownOn && !afterTrigger){
			afterTrigger = true;
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
			TimerGUI.SetActive(true);
			PhysicalTimer.SetActive(true);
		}
	}
}
