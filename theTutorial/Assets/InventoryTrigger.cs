using UnityEngine;
using System.Collections;

public class InventoryTrigger : MonoBehaviour {
	
	string inventoryExplanation = "Now i will explain how the inventory works: ";
	
	string inventoryExplanation2 = "Find the three cakes.";
	
	string arrow = "This arrow will help you to find the way";
	
	const int TEXT_MAX = 3;
	
	string[] text = new string[TEXT_MAX];
	
	GameObject GUIdialog, Arrow;
	
	bool afterTrigger = false;

	// Use this for initialization
	void Start () {
		
		text[0] = inventoryExplanation;
		text[1] = inventoryExplanation2;
	
		GUIdialog = GameObject.Find("GUI Text");
		Arrow = GameObject.Find("Arrow");
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player"){
			afterTrigger = true;
			Arrow.renderer.enabled = true;
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
		}
	}
}
