using UnityEngine;
using System.Collections;

public class TimerCountdown : MonoBehaviour {
	
	public float seconds = 99f;
	// Use this for initialization
	void Start () {
		this.guiText.text = seconds.ToString();
		InvokeRepeating("Countdown",seconds,1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Countdown (){
		seconds--;
		if (seconds == 0){
			CancelInvoke("Countdown");
		}
		this.guiText.text  = seconds.ToString();
	}
}