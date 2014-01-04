using UnityEngine;
using System.Collections;

public class CursorInitialMenu : MonoBehaviour {
	
	public GameObject[] MenuOption;
	
	const int DELTA_MOVE = 130;
	
	const float DELTA_SCALE = 1.1f;
	
	const int MAX_POS = 3;
	
	int position = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown("up"))
		{
			moveCursorUp();
		}
		
		if(Input.GetKeyDown("down"))
		{
			moveCursorDown();
		}
		
		if(Input.GetKeyDown(KeyCode.Return)){
			
			switch(position){
				
			case 0 : Application.LoadLevel("FirstLevel");
					 break;
				
			case 1 : Application.LoadLevel("Level_2");
				     break;
				
			case 2 : Application.Quit();
					 break;
			}
		}
		
		
	
	}
	
	void moveCursorDown(){
		
		if(position < (MAX_POS - 1)){
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
