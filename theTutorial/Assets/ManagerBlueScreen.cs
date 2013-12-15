using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public enum textState{
		NORMAL, 
		DRUNK, 
		DRESS, 
		DRUNK_ELPHANT,
		CAKE
	}
	

public class ManagerBlueScreen : MonoBehaviour {
	
	
	string angry = "I SAID TO NOT PRESS ESC, YOU &%$%&";
	string textGame1 = "Now i have to fix this mess.";
	string textGame2 = "In the while, play this textual game";
	string textGame3 = "Beware to not break anything, ok?";
	
	string loadingParallelWorld = "Loading Korz, please wait...";
	
	string[] text, textGUI;
	
	bool begin = true;
	
	GameObject managerCamera, blueScreen, GUIdialog, HUDMenu;
	
	int textPosition = 0;
	int cursorPosition = 0;
	
	int line;
	
	float Timer;
	
	public GameObject[] lines;
	public GameObject[] options;
	public GameObject cursor;
	
	TextMesh output;
	
	const int MAX_CHAR = 45;
	const int MAX_LINES = 4;
	const float DELTA_X = 478;
	const float DELTA_Y = 60;
	
	XMLparser textGame;
	
	textState myState = textState.NORMAL;
	
	Node tree;

	// Use this for initialization
	void Start () {
		
		output = lines[0].GetComponent<TextMesh>();
		
		textGUI = new string[5];
		
		textGUI[0] = angry;
		
		textGUI[1] = textGame1;
		textGUI[2] = textGame2;
		textGUI[3] = textGame3;
		textGUI[4] = loadingParallelWorld;
		
		XMLparser textGame = new XMLparser(Application.dataPath + "/TextGame.xml"); 
		tree = textGame.getRoot();
		
		text = tree.getOutput(myState);
		
		managerCamera = GameObject.Find ("ManagerCamera");
		
		GUIdialog = GameObject.Find("GUI Text");
		
		HUDMenu = GameObject.Find ("HUDMenu");
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Globals.currentLevel == Level.BLUESCREEN){
			
			if(begin){
				writeBegin();
				begin = false;
			}
			
			if(Input.GetKeyDown("k")){ 
				if(text[textPosition]!= null){
					writeOutput();
					writeOptions();
					textPosition++;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.Return)){
				if(cursorPosition <= tree.numChilds){
					tree = tree.getChild(cursorPosition);
					
					changeState();
					checkCake();
					text = tree.getOutput(myState);
					clearOutput();
					writeOutput();
					writeOptions();
					textPosition++;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.E)) {
				Globals.currentLevel = Level.INVENTORY;
				Debug.Log(Globals.currentLevel);
				writeEnd();
				managerCamera.GetComponent<ManagerCamera>().getCamera("BlueScreenCamera").active = false;
				managerCamera.GetComponent<ManagerCamera>().getCamera("RigidbodyController").active = true;
				HUDMenu.guiTexture.enabled = true;
				
			}
			
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				if(cursorPosition == 0 || cursorPosition == 2){
					cursor.transform.Translate(Vector3.right*DELTA_X);
					if(cursorPosition == 0)
						cursorPosition = 1;
					
					if(cursorPosition == 2) 
						cursorPosition = 3;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				if(cursorPosition == 1 || cursorPosition == 3){
					cursor.transform.Translate(Vector3.left*DELTA_X);
					if(cursorPosition == 1)
						cursorPosition = 0;
					
					if(cursorPosition == 3) 
						cursorPosition = 2;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				if(cursorPosition == 2 || cursorPosition == 3){
					cursor.transform.Translate(Vector3.up*DELTA_Y);
					
					if(cursorPosition == 2) 
						cursorPosition = 0;
					
					if(cursorPosition == 3) 
						cursorPosition = 1;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				if(cursorPosition == 0 || cursorPosition == 1){
					cursor.transform.Translate(Vector3.down*DELTA_Y);
					
					if(cursorPosition == 0) 
						cursorPosition = 2;
					
					if(cursorPosition == 1) 
						cursorPosition = 3;
				}
			}
				
			
		}
		
		
	
	}
	
	void writeOptions(){
		for(int i = 0; i < tree.numChilds; i++){
			options[i].GetComponent<TextMesh>()
				.text = tree.childs[i].command;
		}
		
		options[tree.numChilds].GetComponent<TextMesh>()
				.text = "Return back";
	}
	
	void writeOutput(){
		
		int counter = 0;
		
		if(line == MAX_LINES)
			shiftText();
			
		Regex regex = new Regex(@"\s");
		string[] words;
		
		output = lines[line].GetComponent<TextMesh>();
		
		if((text[textPosition] as string).Length > MAX_CHAR){
			
			words = regex.Split(text[textPosition]);
			
			foreach(string s in words){
				
				// + 1 for whitespace
				counter += s.Length + 1;
				
				
				if(counter > MAX_CHAR){
					line++;
					output = lines[line].GetComponent<TextMesh>();
					counter = s.Length;
				}
				
				output.text += s + " ";
				
			}
			
		}
		else
			output.text = text[textPosition];
	
		line++;
	}
	
	void shiftText(){
		line--;
		
		for(int i = 0; i < MAX_LINES - 1 ; i++){
			lines[i].GetComponent<TextMesh>().text = lines[i+1].GetComponent<TextMesh>().text;
		}
		
	}
	
	void clearOutput(){
		line = 0;
		textPosition = 0;
		
			
		for(int i = 0; i < MAX_LINES ; i++){
			lines[i].GetComponent<TextMesh>().text = "";
			options[i].GetComponent<TextMesh>().text = "";
		}
	}
	
	void writeBegin(){
		GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(textGUI);
	}
	
	void writeEnd(){
		textGUI = new string[3];
		textGUI[0] = "Ok, i've fix it";
		textGUI[1] = "Now i will continue with your tutorial";
		textGUI[2] = "";
		GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(textGUI);
	}
	
	void changeState(){
		
		if(myState == textState.NORMAL){
			if(tree.name == "drink")
				myState = textState.DRUNK;
			if(tree.name == "costume")
				myState = textState.DRESS;
		}
		
		if(myState == textState.DRESS && tree.name == "drink")
			myState = textState.DRUNK_ELPHANT;
		
		if(myState == textState.DRUNK && tree.name == "costume")
			myState = textState.DRUNK_ELPHANT;
		
		if(myState == textState.DRUNK_ELPHANT && tree.name == "cake")
			myState = textState.CAKE;
	}
	
	void checkCake(){
		if(myState == textState.CAKE){
			GameObject.Find("Key3").renderer.enabled = true;
		}
	}
}
