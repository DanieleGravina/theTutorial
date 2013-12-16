using UnityEngine;
using System.Collections;

public enum MenuState{
	AUDIO,
	CONTROLS, 
	ACHIEVEMENTS,
	EXIT
}

public class MenuGame : MonoBehaviour {
	
	public GameObject InitialMenu;
	public GameObject ExitMenu;
	public GameObject cake;
	GameObject tmp;
	Transform menu;
	
	Vector3 positionMenu = new Vector3(24f+165f, -74.67452f, 24.47535f);

	// Use this for initialization
	void Start () {
		menu = GameObject.Find("4_Menu").GetComponent<Transform>();
		if(Globals.cakeTaken){
			Instantiate(cake, new Vector3(157f, 1.5f, 1f), Quaternion.identity);
			cake.transform.Rotate(new Vector3(270, 0, 0));
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Change the state of menu text, called(buttons) by children on trigger events
	public void ChangeState(MenuState actualState){
		
		switch(actualState){
			
		case MenuState.EXIT: 
			Destroy(InitialMenu);
			tmp = Instantiate(ExitMenu, positionMenu, Quaternion.identity) as GameObject;
			tmp.transform.parent = menu;
			break;
		}
	}
}
