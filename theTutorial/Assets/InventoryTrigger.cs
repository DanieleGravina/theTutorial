using UnityEngine;
using System.Collections;

public class InventoryTrigger : MonoBehaviour {
	
	string inventoryExplanation = "Now i will show how the inventory works: ";
	
	string inventoryExplanation2 = "Find the three hidden cubes.";
	
	string arrow = "This arrow will help you to find the way";
	
	string joke = "Because you not seem very intelligent";
	
	string joke2 = "No offense";
	
	const int TEXT_MAX = 5;
	
	string[] text = new string[TEXT_MAX];
	
	GameObject GUIdialog, Arrow, managerCamera, HUDMenu, HUDInventory;
	
	bool afterTrigger = false;

	// Use this for initialization
	void Start () {
		
		text[0] = inventoryExplanation;
		text[1] = inventoryExplanation2;
		text[2] = arrow;
		text[3] = joke;
		text[4] = joke2;
	
		GUIdialog = GameObject.Find("GUI Text");
		Arrow = GameObject.Find("Arrow");
		managerCamera = GameObject.Find ("ManagerCamera");
		HUDMenu = GameObject.Find ("HUDMenu");
		HUDInventory = GameObject.Find("Inventory");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Globals.currentLevel == Level.INVENTORY){
			 if (Input.GetKeyDown(KeyCode.Escape) && afterTrigger){
				managerCamera.GetComponent<ManagerCamera>().getCamera("RigidbodyController").active = false;
				managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active = true;
				HUDMenu.guiTexture.enabled = false;
				
				if(HUDInventory.guiTexture.enabled){
					HUDInventory.guiTexture.enabled = false;
					Globals.hasHUDInventory = true;
				}
			}
		}

	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player" && !afterTrigger){
			afterTrigger = true;
			Arrow.renderer.enabled = true;
			Arrow.transform.GetChild(0).renderer.enabled = true;
			Arrow.SendMessage("highLight");
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
		}
	}
}
