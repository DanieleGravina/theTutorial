using UnityEngine;
using System.Collections;

public enum Level{
	MENU,
	BLUESCREEN,
	INVENTORY
}

public class Globals : MonoBehaviour {
	
	public static bool cakeTaken = false;
	
	public static int life = 99;
	
	public static int numInventory;
	
	public static Level currentLevel;
	
	public static float TIMEOUT = 5.0f;
	
	public static Vector3 playerPositionLevel2; 

	// Use this for initialization
	void Start () {
	
		playerPositionLevel2 = new Vector3(-7f, 1.5f, 152f);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
