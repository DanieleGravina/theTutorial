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
	
	Vector3 positionMenu = new Vector3(0.6936188f+165f, -74.67452f, 24.47535f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Change the state of menu text, called(buttons) by children on trigger events
	public void ChangeState(MenuState actualState){
		
		switch(actualState){
			
		case MenuState.EXIT: 
			Destroy(InitialMenu);
			Instantiate(ExitMenu, positionMenu, Quaternion.identity);
			break;
		}
	}
}
