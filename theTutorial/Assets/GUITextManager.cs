using UnityEngine;
using System.Collections;

public class GUITextManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void WriteOutputOnGUI(string text){
		guiText.text = text;
	}
}
