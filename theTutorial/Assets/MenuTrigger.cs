using UnityEngine;
using System.Collections;

public class MenuTrigger : MonoBehaviour {
	
	string welcome = "Oh you're back!";
	
	string menuExplanation = "Now i will explain how the menu works: ";
	
	string menuExplanation2 = "Press Esc button to show the menu.";
	
	const int TEXT_MAX = 3;
	
	string[] text = new string[TEXT_MAX];
	
	GameObject GUIdialog;
	
	GameObject player;
	
	GameObject managerCamera, menu, blueScreen;
	
	public GameObject StateLevel, GUIManager, HUDMenu;
	
	bool afterTrigger = false;

	// Use this for initialization
	void Start () {
		
		text[0] = welcome;
		text[1] = menuExplanation;
		text[2] = menuExplanation2;
		
		managerCamera = GameObject.Find ("ManagerCamera");
	
		GUIdialog = GameObject.Find("GUI Text");
	}
	
	// Update is called once per frame
	void Update () {
			
		 if (Input.GetKeyDown(KeyCode.Escape) && afterTrigger){
			managerCamera.GetComponent<ManagerCamera>().getCamera("RigidbodyController").active = false;
			managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active = true;
			StateLevel.GetComponent<StateLevel>().CurrentLevel = Level.MENUSCREEN;
			GUIManager.SetActive(false);
		}
	
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player" && !afterTrigger){
			StateLevel.GetComponent<StateLevel>().CurrentLevel = Level.MENU;
			afterTrigger = true;
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
		}
	}
}
