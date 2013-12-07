using UnityEngine;
using System.Collections;

public class MenuTrigger : MonoBehaviour {
	
	string welcome = "Welcome to the second part of the tutorial";
	
	string menuExplanation = "Now i will explain how the menu works";
	
	string menuExplanation2 = "press the 'Esc' button to access the menu";
	
	GameObject GUIdialog;
	
	GameObject player;
	
	GameObject menu, blueScreen;
	
	bool afterTrigger = false;

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("RigidbodyController");
		
		menu = GameObject.Find("MenuCamera");
		
		blueScreen = GameObject.Find("BlueScreenCamera");
	
		GUIdialog = GameObject.Find("GUI Text");
	}
	
	// Update is called once per frame
	void Update () {
		
		 if (Input.GetKeyDown(KeyCode.Escape) && afterTrigger){
			player.active = false;
			menu.active = true;
		}
	
	}
	
	void OnTriggerEnter(Collider other){
		
		Globals.currentLevel = Level.MENU;
		
		if(other.tag == "Player"){
			BeginMenuSequence();
			afterTrigger = true;
		}
	}
	
	void BeginMenuSequence(){
		
		GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(welcome);
		
		GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(menuExplanation);
		
		GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(menuExplanation2);
		
		
		
	}
}
