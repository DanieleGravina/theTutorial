using UnityEngine;
using System.Collections;

public class Manager :MonoBehaviour{
	
	
	private Vector3 RIGHT = new Vector2(1, 0);
	
	private Vector3 LEFT = new Vector3(-1, 0);
	
	private Vector3 UP = new Vector3(0, 1);
	
	private Vector3 DOWN = new Vector3(0, -1);
	
	const int DELTA_HUD = 10;
	const int DELTA_ROOM = 18;
	
	const int MAX_X = 6;
	const int MAX_Y = 6;
	
	int[,] map = new int[MAX_X,MAX_Y];
	
	// Use this for initialization
	void Start () {
		
		
		/* Map initialization (number = ID)
		 * 
		 * 0 0 0 0 0 0
		 * 0 1 0 0 4 0
		 * 0 2 0 0 5 0
		 * 0 3 0 0 6 0
		 * 0 7 7 7 7 0
		 * 0 0 0 0 0 0
		 */ 
		
		map[1,1] = 1;
		map[1,4] = 4;
		map[1,1] = 2;
		map[1,4] = 5;
		map[2,1] = 3;
		map[2,4] = 6;
		
		for(int i = 1; i<5; i++)
			map[4,i] = 7;
		
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
					RoomElem.transform.Translate(Vector3.forward*DELTA_ROOM);
					collider.gameObject.transform.Translate(Vector3.forward);
					platform.transform.Translate(Vector3.forward);
				}
				break;
				
			case buttons.LEFT:
				if(updateMap(ID, 0, -1)){
					HUDelem.transform.Translate(LEFT.x/DELTA_HUD, LEFT.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.left*DELTA_ROOM);
					collider.gameObject.transform.Translate(Vector3.left);
					platform.transform.Translate(Vector3.left);
				}
				break;
				
			case buttons.RIGHT:
				if(updateMap(ID, 0, 1)){
					HUDelem.transform.Translate(RIGHT.x/DELTA_HUD, RIGHT.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.right*DELTA_ROOM);
					collider.gameObject.transform.Translate(Vector3.right);
					platform.transform.Translate(Vector3.right);
				}
				break;
				
			case buttons.DOWN:
				if(updateMap(ID, 1, 0)){
					HUDelem.transform.Translate(DOWN.x/DELTA_HUD, DOWN.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.back*DELTA_ROOM);
					collider.gameObject.transform.Translate(Vector3.back);
					platform.transform.Translate(Vector3.back);
				}
				break;
				
			}
		
	}
	
	bool updateMap(int ID, int delta_x, int delta_y){
		
		MyVector2 pos = findPos(ID);
		
		if (validPosition(pos, delta_x, delta_y) && map[pos.x  + delta_x, pos.y + delta_y] == 0){
			
			map[pos.x + delta_x, delta_y + delta_y] = ID;
			map[pos.x, pos.y] = 0;
			return true;
		}else{
			return false;
		}
		
	}
	
	bool validPosition(MyVector2 pos, int delta_x, int delta_y){
		
		int new_x = pos.x + delta_x;
		int new_y = pos.y + delta_y;
		
		if( (new_x > 0 && new_x < MAX_X) && (new_y > 0 && new_y < MAX_Y)) 
			return true;
		else
			return false;
		
	}
	
    MyVector2 findPos(int ID){
		
		for(int i = 0; i < 6; i++)
			for(int j = 0; j < 6; j++){
			
			if(map[i,j] == ID)
				return new MyVector2(i,j);
				
		}
		
		return new MyVector2(0,0);
	}
	
	//don't ask
	public class MyVector2{
		
		public int x;
		public int y;
		
		public MyVector2(int x, int y){
			x = x;
			y = y;
		}
		
	}
	
}
