using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (Globals.level){
			case Globals.LoadType.LEVEL_1:
				if(Application.GetStreamProgressForLevel("FirstLevel") == 1){
					Application.LoadLevel("FirstLevel");
				}
				break;
			case Globals.LoadType.LEVEL_2:
				if(Application.GetStreamProgressForLevel("Level_2") == 1){
					Application.LoadLevel("Level_2");
				}
				break;
			case Globals.LoadType.LEVEL_3:
				if(Application.GetStreamProgressForLevel("FinalLevel") == 1){
					Application.LoadLevel("FinalLevel");
				}
				break;
		}
	}
}