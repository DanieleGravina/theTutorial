using UnityEngine;
using System.Collections;

public class SplashScreen2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Invoke ("SplashScreen", 1f);
		
	}
	
	void SplashScreen(){
		Application.LoadLevel("SplashScreen2");
	}
}
