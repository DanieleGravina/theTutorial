using UnityEngine;
using System.Collections;

public class ManagerCamera : MonoBehaviour {
	
	GameObject player, menu, blueScreen;

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("RigidbodyController");
		
		menu = GameObject.Find("MenuCamera");
		
		blueScreen = GameObject.Find("BlueScreenCamera");
		
		menu.active = false;
		
		blueScreen.active = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public GameObject getCamera(string nameCamera){
		
		if(nameCamera == player.name)
			return player;
		else
			if(nameCamera == menu.name)
				return menu;
			else
				if(nameCamera == blueScreen.name)
					return blueScreen;
		
		//error
		return null;
	}
	
}
