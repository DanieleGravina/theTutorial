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
	
	string explainMenu = "This is the menu, with four option: ";
		
	string explainMenu2  =	"Controls, Audio, Achievement and Exit.";
		
	string exit = "DO NOT SELECT EXIT. ";
	
	string exit2 = "We have some serious problem ";
	
	string exit3 = "with the exit button, so pay attention";
	
	string tryAudio = "Try to select Achievement";
	
	string joke = "Have you any problem?";
	
	string[] text;
	
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
	
	const float TIMEOUT = 8.0f;
	
	bool begin = true;

	// Use this for initialization
	void Start () {
		
		text = new string[6];
		text[0] = explainMenu;
		text[1] = explainMenu2;
		text[2] = exit;
		text[3] = exit2;
		text[4] = exit3;
		text[5] = tryAudio;
	
		managerCamera = GameObject.Find ("ManagerCamera");
		
		GUIdialog = GameObject.Find("GUI Text");
		
		MenuOption[position].transform.localScale += new Vector3(DELTA_SCALE, DELTA_SCALE, DELTA_SCALE);

	}
	
	// Update is called once per frame
	void Update () {
		
		if(managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active){
			
			
			timer += Time.deltaTime;
			
			if(begin){
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
				begin = false;
			}
			
			
			if(Input.GetKeyDown("up"))
			{
				getInput("UP");
			}
			
			if(Input.GetKeyDown("down"))
			{
				getInput("DOWN");
			}
			
			if(Input.GetKeyDown("left")){
				getInput("LEFT");
			}
			
			if(Input.GetKeyDown("right")){
				getInput("RIGHT");
			}
			
			if(Input.GetKeyDown(KeyCode.Return) && position == 3){
				Globals.currentLevel = Level.BLUESCREEN;
				managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active = false;
				managerCamera.GetComponent<ManagerCamera>().getCamera("BlueScreenCamera").active = true;
			}
			
			if(timer >= TIMEOUT){
				
				text = new string[1];
				text[0] = joke;
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
				myState = state.JOKE;
				timer = 0.0f;
			}
			
		}
		
		
	
	}
	
	void getInput(string input){
		
		if(myState == state.NORMAL){
			
			if(input == "DOWN")
				moveCursorDown();
			else
				moveCursorUp();
			
		}
		else
		{
			// random arrow to move up and down in the menu
			int decisionArrow = Mathf.CeilToInt(Random.Range(0,10)%4); 
			int decisionMove = Mathf.CeilToInt(Random.Range(0,10)%2); 
			arrow myArrow = (arrow)decisionArrow;
	
			if(input == myArrow.ToString())
				if(decisionMove == 0)
					moveCursorDown();
				else
					moveCursorUp();
			
//			GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(joke);
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
