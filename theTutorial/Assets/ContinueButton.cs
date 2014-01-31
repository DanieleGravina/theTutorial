using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {
	
	public GameObject selectionSound;
	public float DelayOnClick;

	UIButton button;
	
	void Start(){
		button = GetComponent<UIButton>();
		
		if(Globals.buttonLevel == Globals.ButtonLevel.LEVEL_2)
			button.isEnabled = true;
		else
			button.isEnabled = false;
	}
	
	void OnClick(){	
		selectionSound.audio.Play();
		Invoke("Load", DelayOnClick);
	}
	
	void Load() {
		Globals.level = Globals.LoadType.LEVEL_2;
		Application.LoadLevel("Loading");
	}
}
