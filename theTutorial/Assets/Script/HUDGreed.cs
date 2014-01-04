using UnityEngine;
using System.Collections;

public class HUDGreed : MonoBehaviour {
	
	public Texture texture;
	
	public enum sd{
		pixels, screen_percent
	};
	
	public enum ha{
		left, center, right
	};
	
	public enum va{
		top, middle, bottom
	};
	
	public ha horizontalAlignment = ha.left;
	public va verticalAlignment = va.top;
	
	public int width = 50;
	public int height = 50;
	
	public sd dimensionIn = sd.pixels;
	
	public float xOffset = 0.0f;
	public float yOffset = 0.0f;
	
	int hsize, vsize, hLoc, vLoc;

	// Use this for initialization
	void Start () {
		
        hsize = Mathf.RoundToInt(width * 0.01f * Screen.width);
	    vsize = Mathf.RoundToInt(height * 0.01f * Screen.height);
		
		hLoc = Mathf.RoundToInt(xOffset * 0.01f * Screen.width);
		vLoc = Mathf.RoundToInt(yOffset * 0.01f * Screen.height);
		
		if(dimensionIn == sd.pixels){
			hsize = height;
			vsize = width;
		}
		
		switch(horizontalAlignment){
			
		case ha.left: 
			hLoc = Mathf.RoundToInt(xOffset * 0.01f * Screen.width);
			break;
			
		case ha.right :
			hLoc = Mathf.RoundToInt((Screen.width - hsize) - (xOffset * 0.01f * Screen.width));
			break;
			
		case ha.center :
			hLoc = Mathf.RoundToInt((Screen.width - 0.05f) - (xOffset * 0.01f * Screen.width));
			break;	
		}
		
		switch(verticalAlignment){
			
		case va.top:
			vLoc = Mathf.RoundToInt((Screen.height - vsize) - (yOffset * 0.01f * Screen.height));
			break;
			
		case va.middle :
			vLoc = Mathf.RoundToInt((Screen.height - 0.5f) - (vsize * 0.5f) - (yOffset * 0.01f * Screen.height));
			break;
			
		case va.bottom :
			vLoc = Mathf.RoundToInt(yOffset * 0.01f * Screen.height);
			break;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onGUI(){
		
		Rect indicator = new Rect(hLoc, vLoc, hsize, vsize);
		GUI.DrawTexture(indicator, texture);
	}
		
		
}
