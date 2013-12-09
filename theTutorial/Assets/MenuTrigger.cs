using UnityEngine;
using System.Collections;

public class MenuTrigger : MonoBehaviour {
	
	string welcome = "Welcome to the second part of the tutorial!";
	
	string menuExplanation = "Now i will explain how the menu works: ";
	
	string menuExplanation2 = "press the 'Esc' button to access the menu";
	
	const int TEXT_MAX = 3;
	
	string[] text = new string[TEXT_MAX];
	
	int textPos = 0;
	
	GameObject GUIdialog;
	
	GameObject player;
	
	GameObject managerCamera, menu, blueScreen;
	
	bool afterTrigger = false;

	// Use this for initialization
	void Start () {
		
		text[0] = welcome;
		text[1] = menuExplanation;
		text[2] = menuExplanation2;
		
		managerCamera = GameObject.Find ("ManagerCamera");
	
		GUIdialog = GameObject.Find("GUI Text");
		
		GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text[textPos]);
		textPos++;
	}
	
	// Update is called once per frame
	void Update () {
		
		 if (Input.GetKeyDown(KeyCode.Escape) && afterTrigger){
			managerCamera.GetComponent<ManagerCamera>().getCamera("RigidbodyController").active = false;
			managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active = true;
		}
		
		if(Input.GetKeyDown(KeyCode.Return)){
			if(textPos < TEXT_MAX){
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text[textPos]);
				textPos++;
			}
		}
	
	}
	
	void OnTriggerEnter(Collider other){
		
		Globals.currentLevel = Level.MENU;
		
		if(other.tag == "Player"){
			afterTrigger = true;
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text[textPos]);
			textPos++;
		}
	}
}
