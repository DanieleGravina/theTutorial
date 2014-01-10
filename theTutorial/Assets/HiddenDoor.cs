using UnityEngine;
using System.Collections;

public class HiddenDoor : MonoBehaviour {
	
	GameObject fakeWall;

	// Use this for initialization
	void Start () {
		
		fakeWall = GameObject.Find ("FakeWall");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void hideDoor(){
		Instantiate(fakeWall);
	}
	
	public void showHiddenDoor(){
		Destroy (fakeWall);
	}
}
