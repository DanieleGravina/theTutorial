using UnityEngine;
using System.Collections;

public class TutorialButton : MonoBehaviour {
	
	public GameObject selectionSound;
	
	public float DelayOnClick;
	
	void OnClick(){	
		selectionSound.audio.Play();
		Invoke("Load", DelayOnClick);
	}
	
	void Load() {
		Globals.level = Globals.LoadType.LEVEL_1;
		Application.LoadLevel("Loading");
	}
}
