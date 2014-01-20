using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Globals.levelOne){
			if(Application.GetStreamProgressForLevel("FirstLevel") == 1){
				Application.LoadLevel("FirstLevel");
			}
		}else{
			if(Application.GetStreamProgressForLevel("Level_2") == 1){
				Application.LoadLevel("Level_2");
			}
		}
	}
}
