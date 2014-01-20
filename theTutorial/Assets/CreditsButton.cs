using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {
	
	public GameObject selectionSound;
	public float DelayOnClick;
	
	void OnClick(){	
		selectionSound.audio.Play();
		Invoke("Load", DelayOnClick);
	}
	
	void Load() {
		Application.LoadLevel("Credits");
	}
}
