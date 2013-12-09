using UnityEngine;
using System.Collections;

public class TimerCountdown : MonoBehaviour {
	
	public float init_seconds = 100f;
	float seconds;
	// Use this for initialization
	void Start () {
		seconds= init_seconds;
		this.GetComponent<GUIText>().text = seconds.ToString();
		InvokeRepeating("Countdown",1f,1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Countdown (){
		seconds--;
		if (seconds == 0){
			//CancelInvoke("Countdown");
			seconds = init_seconds;
		}
		this.GetComponent<GUIText>().text = seconds.ToString();
	}
	
	public void setSeconds() {
		seconds = init_seconds;
	}
}