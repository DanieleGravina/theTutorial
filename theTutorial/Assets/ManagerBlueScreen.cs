using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ManagerBlueScreen : MonoBehaviour {
	
	string loadingParallelWorld = "Loading Korz, please wait...";
	
	string ExplainParallel = "Press P to go on the parallel world";
	
	string CakeInTheTextGame = "To get the cake key, try the bluescreen textual game";
	
	string[] text;
	
	GameObject managerCamera, blueScreen;
	
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
	
	Node tree;

	// Use this for initialization
	void Start () {
		
		output = lines[0].GetComponent<TextMesh>();
		
		/*text = new string[4];
		
		text[0] = ExplainParallel;
		
		text[1] = CakeInTheTextGame;
		
		text[2] = loadingParallelWorld;*/
		
		XMLparser textGame = new XMLparser(Application.dataPath + "/TextGame.xml"); 
		tree = textGame.getRoot();
		
		text = tree.Output;
		
		managerCamera = GameObject.Find ("ManagerCamera");
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Globals.currentLevel == Level.BLUESCREEN){
			
			if(Input.GetKeyDown("k")){ 
				if(text[textPosition]!= null){
					writeOutput();
					writeOptions();
					textPosition++;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.Return)){
				if(cursorPosition < tree.numChilds){
					tree = tree.getChild(cursorPosition);
					text = tree.Output;
					clearOutput();
					writeOutput();
					writeOptions();
					textPosition++;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.E)) {
				Globals.currentLevel = Level.INVENTORY;
				Debug.Log(Globals.currentLevel);
				
				//Globals.playerPositionLevel2 = GameObject.Find("RigidbodyController").transform.position;
				//Application.LoadLevel("HUD_Level");
				managerCamera.GetComponent<ManagerCamera>().getCamera("BlueScreenCamera").active = false;
				managerCamera.GetComponent<ManagerCamera>().getCamera("RigidbodyController").active = true;
				
			}
			
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				cursor.transform.Translate(Vector3.right*DELTA_X);
				//cursorPosition++;
			}
			
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				cursor.transform.Translate(Vector3.left*DELTA_X);
				//cursorPosition--;
			}
			
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				cursor.transform.Translate(Vector3.up*DELTA_Y);
				//cursorPosition -= 2;
			}
			
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				cursor.transform.Translate(Vector3.down*DELTA_Y);
				//cursorPosition += 2;
			}
				
			
		}
		
		
	
	}
	
	void writeOptions(){
		for(int i = 0; i < tree.numChilds; i++){
			options[i].GetComponent<TextMesh>()
				.text = tree.childs[i].command;
		}
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
}
