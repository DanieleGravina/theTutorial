using UnityEngine;
using System.Collections;

public enum state{
	NORMAL, 
	JOKE
}

public class Selector : MonoBehaviour {
	
	string explainManu = "This is the menu, with four option: Controls, Audio, Achievement and Exit.";
		
	string exit = " DO NOT SELECT EXIT. We have some serious problem with the exit button, so pay attention";
	
	string tryAudio = "Try to select audio";
	
	string joke = "Have you any problem?";
	
	GameObject menu, GUIdialog, blueScreen;
	
	
	//say in witch state it's the menu
	state myState = state.NORMAL;
	
	const int DELTA_MOVE = 130;
	
	
	//position of the cursor
	int position = 0;
	
	// num of option in the menu
	const int MAX_POS = 4;
	
	float timer = 0.0f;
	
	const float TIMEOUT = 5.0f;
	
	bool begin = true;

	// Use this for initialization
	void Start () {
	
		menu = GameObject.Find("MenuCamera");
		blueScreen = GameObject.Find("BlueScreenCamera");
		
		menu.active = false;
		
		GUIdialog = GameObject.Find("GUI Text");

	}
	
	// Update is called once per frame
	void Update () {
		
		if(menu.active){
			
			
			timer += Time.deltaTime;
			
			if(begin){
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(explainManu);
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(exit);
				begin = false;
			}
			
			if(Input.GetKeyDown("down"))
			{
				if(myState == state.NORMAL)
					moveCursorDown();
				else
				{
					moveCursorUp();
					GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(joke);
				}
			}
			
			if(Input.GetKeyDown("up"))
			{
				if(myState == state.NORMAL)
					moveCursorUp();
				else
				{
					moveCursorDown();
					GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(joke);
				}
			}
			
			if(Input.GetKeyDown(KeyCode.Return) && position == 3){
				menu.active = false;
				blueScreen.active = true;
			}
			
			if(timer >= TIMEOUT){
					
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(tryAudio);
				myState = state.JOKE;
				timer = 0.0f;
			}
			
		}
		
		
	
	}
	
	void moveCursorDown(){
		
		if(position <= MAX_POS){
			transform.Translate(Vector3.down*DELTA_MOVE);
			position++;
		}
	}
	
	void moveCursorUp(){
		
		if(position > 0){
			transform.Translate(Vector3.up*DELTA_MOVE);
			position--;
		}
		
	}
}
