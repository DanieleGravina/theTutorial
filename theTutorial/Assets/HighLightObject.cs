using UnityEngine;
using System.Collections;

public class HighLightObject : MonoBehaviour {
	
	public Color initialColor;
	public Color highlightColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void highLight(){
		renderer.material.SetColor ("_Emission", highlightColor);
	}
	
	void normalLight(){
		renderer.material.SetColor ("_Emission", initialColor);
	}
}
