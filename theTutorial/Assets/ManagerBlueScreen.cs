using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ManagerBlueScreen : MonoBehaviour {
	
	string ExplainParallel = "Press P to go on the parallel world";
	
	string CakeInTheTextGame = "To get the cake key, try the bluescreen textual game";
	
	string[] text;
	
	GameObject managerCamera, blueScreen;
	
	int textPosition = 0;
	
	int line;
	
	float Timer;
	
	public GameObject[] lines;
	
	TextMesh output;
	
	const int MAX_CHAR = 35;
	const int MAX_LINES = 4;

	// Use this for initialization
	void Start () {
		
		output = lines[0].GetComponent<TextMesh>();
		
		text = new string[3];
		
		text[0] = ExplainParallel;
		
		text[1] = CakeInTheTextGame;
		
		text[2] = "";
		
		managerCamera = GameObject.Find ("ManagerCamera");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Globals.currentLevel == Level.BLUESCREEN){
			
			if(Input.anyKeyDown){
				writeOutput();
				textPosition++;
			}
			
			if(textPosition == 3) {
				Globals.currentLevel = Level.INVENTORY;
				managerCamera.GetComponent<ManagerCamera>().getCamera("RigidbodyController").active = true;
				managerCamera.GetComponent<ManagerCamera>().getCamera("BlueScreenCamera").active = false;
				
			}
				
		}
	
	}
	
	void writeOutput(){
		
		int counter = 0;

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
}
