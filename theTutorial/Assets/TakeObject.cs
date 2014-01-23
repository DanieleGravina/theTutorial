using UnityEngine;
using System.Collections;

public class TakeObject : MonoBehaviour {
	
	RaycastHit hit;
	
	public GameObject inventory;
	public GameObject ObjectTakenSound;
	public GameObject SignalDoorToLife;
	public GameObject StateLevel;
	
	public float FadeOutTimeOut = 1.0f;
	
	GameObject arrow;
	
	bool fadeOutArrow = false;
	float alphaArrow;
	Color colorArrow;
	float Timer = 0.0f;
	
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
		
		if(fadeOutArrow){
			Timer += Time.deltaTime;
			if(Timer >= FadeOutTimeOut){
				alphaArrow -= 0.1f;
				Timer = 0;
			}
			colorArrow.a = alphaArrow;
			arrow.renderer.material.SetColor("_TintColor", colorArrow);
			arrow.transform.GetChild(0).renderer.material.SetColor("_TintColor", colorArrow);
			if(colorArrow.a <= 0f){
				Destroy(arrow);
				fadeOutArrow = false;
			}
		}
	
	}
	
	void setInventoryHUD(){
		
		if(Globals.numInventory == 0)
			inventory.SetActive(true);
		
		inventory.guiTexture.texture = hudInventory[Globals.numInventory];
		
		Globals.numInventory++;
		
		if(Globals.numInventory == 3){
			StateLevel.GetComponent<StateLevel>().CurrentLevel = Level.LIFE;
			//arrow.renderer.enabled = false;
			fadeOutArrow = true;
			Timer = 0;
			alphaArrow = arrow.renderer.material.GetColor("_TintColor").a;
			colorArrow = arrow.renderer.material.GetColor("_TintColor");
			//arrow.transform.GetChild(0).renderer.enabled = false;
			SignalDoorToLife.GetComponent<SignalColorManager>().ChangeSignalColor();
		}
			
	}
	
	
}
	
	
	
	
	
	
	
	
	
	
	
	