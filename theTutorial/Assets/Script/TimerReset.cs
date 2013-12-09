using UnityEngine;
using System.Collections;

public class TimerReset : MonoBehaviour {
	
	GUIText timer;
	
	// Use this for initialization
	void Start () {
		timer = GameObject.Find("timer_text").GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnTriggerEnter (Collider other) {
		Debug.Log("time reset");
		timer.text = "99";
	}
}

