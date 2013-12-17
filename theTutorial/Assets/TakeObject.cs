using UnityEngine;
using System.Collections;

public class TakeObject : MonoBehaviour {
	
	RaycastHit hit;
	GameObject inventory;

	
	public Texture2D[] hudInventory;

	// Use this for initialization
	void Start () {
		
		inventory = GameObject.Find("Inventory");
		Globals.numInventory = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey("e") && Globals.numInventory <= 2){
			
			if(Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.tag == "Key"){
				Destroy(hit.collider.gameObject);
				setInventoryHUD();
			}
				
		}
		
		if(Input.GetKey("g")){
			Application.LoadLevel("HUD_Level");
		}
	
	}
	
	void setInventoryHUD(){
		
		if(Globals.numInventory == 0)
			inventory.guiTexture.enabled = true;
		
		inventory.guiTexture.texture = hudInventory[Globals.numInventory];
		
		Globals.numInventory++;
		
		if(Globals.numInventory == 3)
			Application.LoadLevel("InitialMenu");
			
	}
	
	
}
	
	
	
	
	
	
	
	
	
	
	
	