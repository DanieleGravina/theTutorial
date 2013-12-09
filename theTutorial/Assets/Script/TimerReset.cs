using UnityEngine;
using System.Collections;

public class TimerReset : MonoBehaviour {
	
	GameObject timer;
	
	// Use this for initialization
	void Start () {
		
		timer = GameObject.Find("timer_text");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnTriggerEnter (Collider other) {
		timer.GetComponent<TimerCountdown>().setSeconds();
	}
}

