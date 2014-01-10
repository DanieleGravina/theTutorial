using UnityEngine;
using System.Collections;

public class GuiTexturePosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Rect pixels = guiTexture.pixelInset;
		
		Rect newPixels = new Rect(Screen.height / 2, 0, Screen.width, Screen.width);
		
		guiTexture.pixelInset = newPixels;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
