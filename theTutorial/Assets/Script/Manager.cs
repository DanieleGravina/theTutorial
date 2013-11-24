using UnityEngine;
using System.Collections;

public class Manager :MonoBehaviour{
	
	public int[,] map = new int[5,5];
	
	private Vector3 RIGHT = new Vector2(1, 0);
	
	private Vector3 LEFT = new Vector3(-1, 0);
	
	private Vector3 UP = new Vector3(0, 1);
	
	private Vector3 DOWN = new Vector3(0, -1);
	
	const int DELTA_HUD = 10;
	
	// Use this for initialization
	void Start () {
		
		
		/* Map initialization (number = ID)
		 * 
		 * 1 0 0 0 4
		 * 2 0 0 0 5
		 * 3 0 0 0 6
		 * 7 7 7 7 7
		 * 0 0 0 0 0
		 */ 
		
		map[0,0] = 1;
		map[0,4] = 4;
		map[1,0] = 2;
		map[1,4] = 5;
		map[2,0] = 3;
		map[2,4] = 6;
		
		for(int i = 0; i<5; i++)
			map[3,i] = 7;
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void MovePlatform(int ID, buttons typeButton, GameObject HUDelem, GameObject RoomElem, GameObject platform, Collider collider){
		
		switch(typeButton)
			{
			 
			case buttons.UP:
				
				if(updateMap(ID, -1, 0)){
					HUDelem.transform.Translate(UP.x/DELTA_HUD, UP.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.forward);
					collider.gameObject.transform.Translate(Vector3.forward);
					platform.transform.Translate(Vector3.forward);
				}
				break;
				
			case buttons.LEFT:
				if(updateMap(ID, 0, -1)){
					HUDelem.transform.Translate(LEFT.x/DELTA_HUD, LEFT.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.left);
					collider.gameObject.transform.Translate(Vector3.left);
					platform.transform.Translate(Vector3.left);
				}
				break;
				
			case buttons.RIGHT:
				if(updateMap(ID, 0, 1)){
					HUDelem.transform.Translate(RIGHT.x/DELTA_HUD, RIGHT.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.right);
					collider.gameObject.transform.Translate(Vector3.right);
					platform.transform.Translate(Vector3.right);
				}
				break;
				
			case buttons.DOWN:
				if(updateMap(ID, 1, 0)){
					HUDelem.transform.Translate(DOWN.x/DELTA_HUD, DOWN.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.back);
					collider.gameObject.transform.Translate(Vector3.back);
					platform.transform.Translate(Vector3.back);
				}
				break;
				
			}
		
	}
	
	bool updateMap(int ID, int delta_x, int delta_y){
		
		/*Vector2 pos = findPos(ID);
		
		map[pos.x, pos.y] = 0;
		map[pos.x + delta_x, delta_y + delta_y] = ID;*/
		
		return true;
		
	}
	
    Vector2 findPos(int ID){
		
		return new Vector2(0,0);
	}

	
}
