using UnityEngine;
using System.Collections;

public class TimerReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseOver () {
		if (Input.GetMouseButtonUp(0)){
			Debug.Log("click done");
		}
	}
}
