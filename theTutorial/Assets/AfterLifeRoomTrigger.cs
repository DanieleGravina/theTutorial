using UnityEngine;
using System.Collections;

public class AfterLifeRoomTrigger : MonoBehaviour {
	
	public string[] text;
	
	public GameObject LifeRoom, GuiTimer, BloodTexture;
	
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

			if(BloodTexture.guiTexture.enabled)
				BloodTexture.guiTexture.enabled = false;
			
			if(Globals.CountDownOn){
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
				GuiTimer.GetComponent<TimerManager>().Restart();
			}
		}
	}
}
