using UnityEngine;
using System.Collections;

public enum state{
	NORMAL, 
	JOKE
}

public enum arrow{
	UP,
	DOWN,
	LEFT,
	RIGHT
}

public class Selector : MonoBehaviour {
	
	string explainManu = "This is the menu, with four option: Controls, Audio, Achievement and Exit.";
		
	string exit = " DO NOT SELECT EXIT. We have some serious problem with the exit button, so pay attention";
	
	string tryAudio = "Try to select audio";
	
	string joke = "Have you any problem?";
	
	GameObject menu, GUIdialog, blueScreen, managerCamera;
	
	public GameObject[] MenuOption;
	
	
	//say in witch state it's the menu
	state myState = state.NORMAL;
	
	const int DELTA_MOVE = 130;
	
	const float DELTA_SCALE = 1.1f;
	
	
	//position of the cursor
	int position = 0;
	
	// num of option in the menu
	const int MAX_POS = 3;
	
	float timer = 0.0f;
	
	const float TIMEOUT = 5.0f;
	
	bool begin = true;

	// Use this for initialization
	void Start () {
	
		managerCamera = GameObject.Find ("ManagerCamera");
		
		GUIdialog = GameObject.Find("GUI Text");
		
		MenuOption[position].transform.localScale += new Vector3(DELTA_SCALE, DELTA_SCALE, DELTA_SCALE);

	}
	
	// Update is called once per frame
	void Update () {
		
		if(managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active){
			
			
			timer += Time.deltaTime;
			
			if(begin){
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(explainManu);
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(exit);
				begin = false;
			}
			
			
			if(Input.GetKeyDown("up"))
			{
				getInput("up");
			}
			
			if(Input.GetKeyDown("down"))
			{
				getInput("down");
			}
			
			if(Input.GetKeyDown("left")){
				getInput("left");
			}
			
			if(Input.GetKeyDown("right")){
				getInput("right");
			}
			
			if(Input.GetKeyDown(KeyCode.Return) && position == 3){
				managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active = false;
				managerCamera.GetComponent<ManagerCamera>().getCamera("BlueScreenCamera").active = true;
				Globals.currentLevel = Level.BLUESCREEN;
			}
			
			if(timer >= TIMEOUT){
					
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(tryAudio);
				myState = state.JOKE;
				timer = 0.0f;
			}
			
		}
		
		
	
	}
	
	void getInput(string input){
		
		if(myState == state.NORMAL){
			
			if(input == "down")
				moveCursorDown();
			else
				moveCursorUp();
			
		}
		else
		{
			int decisionArrow = Mathf.CeilToInt(Random.Range(0,10)%4); 
			int decisionMove = Mathf.CeilToInt(Random.Range(0,10)%2); 
			arrow myArrow = arrow.UP;
			
			//if(input == myArrow.toString())
				if(decision == 0)
					moveCursorDown();
				else
					moveCursorUp();
			
			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(joke);
		}
	}
	
	void moveCursorDown(){
		
		if(position < MAX_POS){
			transform.Translate(Vector3.down*DELTA_MOVE);
			MenuOption[position].transform.localScale -= new Vector3(DELTA_SCALE, DELTA_SCALE, DELTA_SCALE);
			position++;
			MenuOption[position].transform.localScale += new Vector3(DELTA_SCALE, DELTA_SCALE, DELTA_SCALE);
		}
	}
	
	void moveCursorUp(){
		
		if(position > 0){
			transform.Translate(Vector3.up*DELTA_MOVE);
			MenuOption[position].transform.localScale -= new Vector3(DELTA_SCALE, DELTA_SCALE, DELTA_SCALE);
			position--;
			MenuOption[position].transform.localScale += new Vector3(DELTA_SCALE, DELTA_SCALE, DELTA_SCALE);
		}
		
	}
}
