using UnityEngine;
using System.Collections;

public class InventoryTrigger : MonoBehaviour {
	
	string inventoryExplanation = "Now i will explain how the inventory works: ";
	
	string inventoryExplanation2 = "Find the three cakes.";
	
	string arrow = "This arrow will help you to find the way";
	
	const int TEXT_MAX = 3;
	
	string[] text = new string[TEXT_MAX];
	
	GameObject GUIdialog, Arrow, managerCamera, HUDMenu;
	
	bool afterTrigger = false;

	// Use this for initialization
	void Start () {
		
		text[0] = inventoryExplanation;
		text[1] = inventoryExplanation2;
	
		GUIdialog = GameObject.Find("GUI Text");
		Arrow = GameObject.Find("Arrow");
		managerCamera = GameObject.Find ("ManagerCamera");
		HUDMenu = GameObject.Find ("HUDMenu");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Globals.currentLevel == Level.INVENTORY){
			 if (Input.GetKeyDown(KeyCode.Escape) && afterTrigger){
				managerCamera.GetComponent<ManagerCamera>().getCamera("RigidbodyController").active = false;
				managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active = true;
				HUDMenu.guiTexture.enabled = false;
			}
		}

	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player"){
			afterTrigger = true;
			Arrow.renderer.enabled = true;
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
		}
	}
}
