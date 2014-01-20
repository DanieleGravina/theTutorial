using UnityEngine;
using System.Collections;

public class HiddenDoor : MonoBehaviour {
	
	GameObject fakeWall;
	
	bool alwaysOpen = false;

	// Use this for initialization
	void Start () {
		
		fakeWall = GameObject.Find ("FakeWall");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void hideDoor(){
		if(!alwaysOpen)
			fakeWall.SetActive(true);
	}
	
	public void showHiddenDoor(){
		if(!alwaysOpen)
			fakeWall.SetActive(false);
	}
	
	public void showHiddenDoorAlways(){
		alwaysOpen = true;
		fakeWall.SetActive(false);
	}
}
