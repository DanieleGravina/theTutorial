using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {
	
	public int DELTA_LIFE = 11;
	
	TextMesh input_text;
	string cake_text = "take cake";
	string add_life = "life +";
	string remove_life = "life -";
	
	int MAX_LENGTH = 10;

	// Use this for initialization
	void Start () {
		input_text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		input_text.text += Input.inputString;
		
		if(input_text.text.EndsWith("\n") || input_text.text.EndsWith("\r")){
			
			string text = input_text.text.Substring(0, input_text.text.Length -1);
		
			if(text == add_life){
				Globals.life += DELTA_LIFE;
			}
			
			if(text == remove_life){
				Globals.life -= DELTA_LIFE;
			}
			
			if(text == cake_text){
				
				Globals.cakeTaken = true;
				Application.LoadLevel("HUD_Level");
				
			}
			
			input_text.text = "";
			
		}

		
		if(input_text.text.Length > MAX_LENGTH){
			
			input_text.text = "";
		}
		  /*foreach (char c in Input.inputString) {
            if (c == "\b"[0])
                if (guiText.text.Length != 0)
                    guiText.text = guiText.text.Substring(0, guiText.text.Length - 1);
                
            else
                if (c == "\n"[0] || c == "\r"[0])
                    print("User entered his name: " + guiText.text);
                else
                    guiText.text += c;
        }*/
	}
}
