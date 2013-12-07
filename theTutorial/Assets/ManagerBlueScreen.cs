using UnityEngine;
using System.Collections;

public class ManagerBlueScreen : MonoBehaviour {
	
	string ExplainParallel = "Press P to go on the parallel world";
	
	string CakeInTheTextGame = "You can found the cake in the text game in the parallel world";
	
	GameObject blueScreen;

	// Use this for initialization
	void Start () {
		blueScreen = GameObject.Find("BlueScreenCamera");
		blueScreen.active = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if(Globals.currentLevel == Level.MENU){
			guiText.text = ExplainParallel;
			Globals.currentLevel = Level.INVENTORY;
		}*/
	
	}
}
