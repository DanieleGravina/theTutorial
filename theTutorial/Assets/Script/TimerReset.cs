using UnityEngine;
using System.Collections;

public class TimerReset : MonoBehaviour {
	
	GameObject timer;
	
	Transform platform;
	
	// Use this for initialization
	void Start () {
		platform = GameObject.Find("3_platform").GetComponent<Transform>().FindChild("MovementTrigger");
		timer = GameObject.Find("timer_text");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnTriggerEnter (Collider other) {
		timer.GetComponent<TimerCountdown>().setSeconds();
		platform.GetComponent<HUDPosition>().active = true;
	}
}

