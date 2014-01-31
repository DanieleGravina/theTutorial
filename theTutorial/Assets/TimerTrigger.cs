using UnityEngine;
using System.Collections;

public class TimerTrigger : MonoBehaviour {
	
	public GameObject StateLevel;
	
	enum timerState{
		BEGIN,
		END
	}
	
	timerState currentState = timerState.BEGIN;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			
			if(!Globals.CountDownOn){
				
				Globals.CountDownOn = true;
				
				Application.LoadLevel("Level_2");
			}
			else {
				Application.LoadLevel("InitialMenu");
				Globals.buttonLevel = Globals.ButtonLevel.FINAL;
				Globals.CountDownOn = false;
			}
			
		}
	}
	
}
