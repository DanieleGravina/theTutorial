using UnityEngine;
using System.Collections;

public class NewGameButton : MonoBehaviour {
	
	public GameObject selectionSound;
	public float DelayOnClick;

	UIButton button;

	void Start(){
		button = GetComponent<UIButton>();

		if(Globals.buttonLevel == Globals.ButtonLevel.FINAL)
			button.isEnabled = true;
		else
			button.isEnabled = false;
	}


	void OnClick(){	
		selectionSound.audio.Play();
		Invoke("Load", DelayOnClick);
	}
	
	void Load() {
		Globals.level = Globals.LoadType.LEVEL_3;
		Application.LoadLevel("Loading");
	}
}
