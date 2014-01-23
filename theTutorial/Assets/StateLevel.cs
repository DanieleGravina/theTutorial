﻿using UnityEngine;
using System.Collections;

public enum Level{
	MENU,
	INVENTORY,
	LIFE,
	MAP,
	TIMER,
	ALL,
	MENUSCREEN,
	BLUESCREEN
}

public class StateLevel : MonoBehaviour {
	
	public GameObject GuiTimer;
	
	public GameObject Player;
	
	public GameObject TimerRespawnPoint;
	
	public Level CurrentLevel = Level.MENU;
	
	public GameObject[] doors;

	// Use this for initialization
	void Start () {
		
		if(Globals.CountDownOn){
			
			Player.transform.position = new Vector3(TimerRespawnPoint.transform.position.x, 
					TimerRespawnPoint.transform.position.y, TimerRespawnPoint.transform.position.z);
			
			GuiTimer.SetActive(true);
			
			GuiTimer.GetComponent<TimerManager>().beginCountDown();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void openAllDoor(){
		
		foreach(GameObject door in doors){
			door.GetComponent<DoorTrigger>().levelDoor = Level.ALL;
		}
	}
}
