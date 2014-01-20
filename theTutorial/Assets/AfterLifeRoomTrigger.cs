using UnityEngine;
using System.Collections;

public class AfterLifeRoomTrigger : MonoBehaviour {
	
	public string[] text;
	
	public GameObject LifeRoom, GuiTimer;
	
	bool afterTrigger = false;
	
	GameObject GUIdialog;

	// Use this for initialization
	void Start () {
		
		GUIdialog = GameObject.Find("GUI Text");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player" && !afterTrigger){
			
			afterTrigger = true;
			
			if(Globals.CountDownOn){
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
				GuiTimer.GetComponent<TimerManager>().Restart();
			}
			
			LifeRoom.GetComponent<HiddenDoor>().showHiddenDoorAlways();
		}
	}
}
