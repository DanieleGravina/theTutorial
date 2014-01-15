using UnityEngine;
using System.Collections;

public class Globals {
	
	#region STATIC VARIABLES
	
	public static bool cakeTaken = false;
	
	public static Level currentLevel = Level.MENU;
	
	public static bool CountDownOn = false;
	
	public static int life = 99;
	
	public static int numInventory;
	
	public static float TIMEOUT = 5.0f;
	
	public static Vector3 playerPositionLevel2 = new Vector3(-7f, 1.5f, 152f); 
	
	public static bool hasHUDInventory = false;

	const int MAX_X = 4;
	const int MAX_Z = 4;
	
	//public static int[,] map = new int[MAX_Z,MAX_X] {{0,0,0,0},{0,1,2,0},{5,4,2,3},{0,0,0,0}};
	public static int[,] map = new int[MAX_Z,MAX_X] {{0,1,2,0},{5,4,2,3},{0,0,0,0},{0,0,0,0}};

	#endregion
}
