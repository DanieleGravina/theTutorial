using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Invoke ("LoadMenu", 1f);
	
	}
	
	void LoadMenu(){
		Application.LoadLevel("InitialMenu");
	}
}
