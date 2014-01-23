using UnityEngine;
using System.Collections;

public class GuiTexturePosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Rect pixels = guiTexture.pixelInset;
		
		Rect newPixels = new Rect( 0, 0, Screen.width/2, Screen.height/2);
		
		guiTexture.pixelInset = newPixels;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
