using UnityEngine;
using System.Collections;

public class SignalColorManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ChangeSignalColor(){
		renderer.material.color = Color.green;
	}
}
