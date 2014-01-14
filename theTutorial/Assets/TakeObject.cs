using UnityEngine;
using System.Collections;

public class TakeObject : MonoBehaviour {
	
	RaycastHit hit;
	
	public GameObject inventory;
	public GameObject ObjectTakenSound;
	public GameObject SignalDoorToLife;
	public GameObject StateLevel;
	
	GameObject arrow;
	
	public Texture2D[] hudInventory;

	// Use this for initialization
	void Start () {
		
		arrow = GameObject.Find("Arrow");
		Globals.numInventory = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey("e") && Globals.numInventory <= 2){
			
			if(Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.tag == "Key"){
				ObjectTakenSound.audio.Play();
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
			inventory.SetActive(true);
		
		inventory.guiTexture.texture = hudInventory[Globals.numInventory];
		
		Globals.numInventory++;
		
		if(Globals.numInventory == 3){
			StateLevel.GetComponent<StateLevel>().CurrentLevel = Level.LIFE;
			arrow.renderer.enabled = false;
			arrow.transform.GetChild(0).renderer.enabled = false;
			SignalDoorToLife.GetComponent<SignalColorManager>().ChangeSignalColor();
		}
			
	}
	
	
}
	
	
	
	
	
	
	
	
	
	
	
	