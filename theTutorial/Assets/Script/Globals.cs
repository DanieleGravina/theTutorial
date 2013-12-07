using UnityEngine;
using System.Collections;

public enum Level{
	MENU, 
	INVENTORY
}

public class Globals : MonoBehaviour {
	
	public static bool cakeTaken = false;
	
	public static int life = 99;
	
	public static int numInventory;
	
	public static Level currentLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
