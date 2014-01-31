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
		
	string explainMenu2  =	"Controls, Audio, Back and Exit.";
		
	string exit = "DO NOT SELECT EXIT. ";
	
	string exit2 = "We have some serious bug ";
	
	string exit3 = "with the exit button, so pay attention";
	
	string tryAudio = "Try to choose Audio";
	
	string finish = " ";
	
	string[] text;
	
	GameObject menu, GUIdialog, blueScreen, managerCamera;
	
	public GameObject StateLevel;
	
	public GameObject[] MenuOption;
	
	public GameObject MenuTitle;
	
	public GameObject SignalDoorToInventory;

	public GameObject GUIManager;

	
	//say in witch state it's the menu
	state myState = state.NORMAL;
	
	const int DELTA_MOVE = 140;
	
	const float DELTA_SCALE = 1.1f;
	
	
	//position of the cursor
	int position = 0;
	
	// num of option in the menu
	const int MAX_POS = 3;
	
	float timer = 0.0f;
	
	const float TIMEOUT = 8.0f;
	
	bool begin = true;
	
	Level currentLevel;

	// Use this for initialization
	void Start () {
		
		text = new string[7];
		text[0] = explainMenu;
		text[1] = explainMenu2;
		text[2] = exit;
		text[3] = exit2;
		text[4] = exit3;
		text[5] = tryAudio;
		text[6] = finish;
	
		managerCamera = GameObject.Find ("ManagerCamera");
		
		GUIdialog = GameObject.Find("GUI Text");
		
		MenuOption[position].transform.localScale += new Vector3(DELTA_SCALE, DELTA_SCALE, DELTA_SCALE);

	}
	
	// Update is called once per frame
	void Update () {
		
		if(StateLevel.GetComponent<StateLevel>().CurrentLevel == Level.MENUSCREEN){
			
			
			//timer += Time.deltaTime;
			
			if(begin){
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
				begin = false;
			}
			
			if(GUIdialog.GetComponent<GUITextManager>().TextCompleted()){
			
			
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
					StateLevel.GetComponent<StateLevel>().CurrentLevel = Level.BLUESCREEN;
					managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active = false;
					managerCamera.GetComponent<ManagerCamera>().getCamera("BlueScreenCamera").active = true;
				}
				
				if(Input.GetKeyDown(KeyCode.Return) && position == 2){
					StateLevel.GetComponent<StateLevel>().CurrentLevel = Level.INVENTORY;
					SignalDoorToInventory.GetComponent<SignalColorManager>().ChangeSignalColor();
					managerCamera.GetComponent<ManagerCamera>().getCamera("MenuCamera").active = false;
					managerCamera.GetComponent<ManagerCamera>().getCamera("RigidbodyController").active = true;
					GUIManager.SetActive(true);
				}
			}
			
			/*if(Input.GetKeyDown(KeyCode.E) && position == 1){
				
				MenuOption[0].GetComponent<TextMesh>()
				.text = "turn up";
				
				MenuOption[1].GetComponent<TextMesh>()
				.text = "turn down";
				
				MenuOption[2].GetComponent<TextMesh>()
				.text = "back";
				
				MenuTitle.GetComponent<TextMesh>()
				.text = "AUDIO";
			}*/
			
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
