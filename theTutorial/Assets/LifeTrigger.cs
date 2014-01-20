﻿using UnityEngine;
using System.Collections;

public class LifeTrigger : MonoBehaviour {
	
	public string[] text;
	//public GameObject[] assetToDisable;
	public GameObject LifeGui;
	
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
			
			/*foreach(GameObject asset in assetToDisable){
				asset.SetActive(false);
			}*/
			
			afterTrigger = true;
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
			LifeGui.guiText.enabled = true;
		}
	}
}