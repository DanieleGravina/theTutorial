using UnityEngine;
using System.Collections;

public class Manager :MonoBehaviour{
	
	
	private Vector3 RIGHT = new Vector2(1, 0);
	
	private Vector3 LEFT = new Vector3(-1, 0);
	
	private Vector3 UP = new Vector3(0, 1);
	
	private Vector3 DOWN = new Vector3(0, -1);
	
	private Rect tmp;
	
	private Camera map_camera;
	private Camera life_camera;
	
	const float DELTA_HUD = 3.35f;   //10
	const int DELTA_ROOM = 56; //18
	const int DELTA_PLATFORM = 4;
	const float DELTA_CAMERA = 0.3f;
	
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
		map[2,1] = 2;
		map[2,4] = 5;
		map[3,1] = 3;
		map[3,4] = 6;
		
		for(int i = 1; i<5; i++)
			map[4,i] = 7;
		
		map_camera = GameObject.Find("Map_camera").camera;
		life_camera = GameObject.Find("Life_camera").camera;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void MovePlatform(int ID, buttons typeButton, GameObject HUDelem, GameObject RoomElem, GameObject platform, Collider collider){
		
		switch(typeButton)
			{
			 
			case buttons.UP:
				if(updateMap(ID, -1, 0,buttons.UP)){
					HUDelem.transform.Translate(UP.x/DELTA_HUD, UP.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.forward*DELTA_ROOM);
					platform.transform.Translate(Vector3.forward * (DELTA_PLATFORM+1));
					if (platform.name == "6_platform"){
						tmp = map_camera.rect;
						tmp.y = tmp.y + DELTA_CAMERA;
						map_camera.rect = tmp ;
					}else if (platform.name == "3_platform"){
						tmp = life_camera.rect;
						tmp.y = tmp.y + DELTA_CAMERA;
						life_camera.rect = tmp ;
					}
				}
				break;
				
			case buttons.LEFT:
				if(updateMap(ID, 0, -1,buttons.LEFT)){
					HUDelem.transform.Translate(LEFT.x/DELTA_HUD, LEFT.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.left*DELTA_ROOM);
					platform.transform.Translate(Vector3.left * DELTA_PLATFORM);
					if (platform.name == "6_platform"){
						tmp = map_camera.rect;
						tmp.x = tmp.x - DELTA_CAMERA;
						map_camera.rect = tmp ;
					}else if (platform.name == "3_platform"){
						tmp = life_camera.rect;
						tmp.x = tmp.x - DELTA_CAMERA;
						life_camera.rect = tmp ;
					}
				}
				break;
				
			case buttons.RIGHT:
				if(updateMap(ID, 0, 1,buttons.RIGHT)){
					HUDelem.transform.Translate(RIGHT.x/DELTA_HUD, RIGHT.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.right*DELTA_ROOM);
					platform.transform.Translate(Vector3.right * DELTA_PLATFORM);
					if (platform.name == "6_platform"){
						tmp = map_camera.rect;
						tmp.x = tmp.x + DELTA_CAMERA;
						map_camera.rect = tmp ;
					}else if (platform.name == "3_platform"){
						tmp = life_camera.rect;
						tmp.x = tmp.x + DELTA_CAMERA;
						life_camera.rect = tmp ;
					}
				}
				break;
				
			case buttons.DOWN:
				if(updateMap(ID, 1, 0,buttons.DOWN)){
					HUDelem.transform.Translate(DOWN.x/DELTA_HUD, DOWN.y/DELTA_HUD, 0, Space.World);
					RoomElem.transform.Translate(Vector3.back*DELTA_ROOM);
					platform.transform.Translate(Vector3.back * (DELTA_PLATFORM+1));
					if (platform.name == "6_platform"){
						tmp = map_camera.rect;
						tmp.y = tmp.y - DELTA_CAMERA;
						map_camera.rect = tmp ;
					}else if (platform.name == "3_platform"){
						tmp = life_camera.rect;
						tmp.y = tmp.y - DELTA_CAMERA;
						life_camera.rect = tmp ;
					}
				}
				break;
				
			}
	}
	
	bool updateMap(int ID, int delta_x, int delta_y,buttons typeButton){
		
		MyVector2 pos = findPos(ID);
		
		if (ID == 7){
			if (typeButton == buttons.RIGHT){
				pos.y = pos.y + 3;
			}else if (typeButton == buttons.DOWN && typeButton == buttons.UP){
				for (int i=0; i<4; i++) {
					if (!(validPosition(pos,delta_x,delta_y + i) && map[pos.x  + delta_x, pos.y + delta_y + i] == 0)){
						return false;
					}
				}
			}
		}
		
		if (validPosition(pos, delta_x, delta_y) && map[pos.x  + delta_x, pos.y + delta_y] == 0){
			map[pos.x + delta_x, pos.y + delta_y] = ID;
			if (ID == 7 && typeButton == buttons.LEFT){
				map[pos.x, pos.y + 3] = 0;
			}else if (ID == 7 && typeButton == buttons.RIGHT){
				map[pos.x, pos.y - 3] = 0;
			}else if ( ID == 7 && (typeButton == buttons.DOWN || typeButton == buttons.UP)){
				for (int i=0;i<4;i++){
					map[pos.x + delta_x, pos.y + delta_y + i] = ID;
					map[pos.x, pos.y + i] = 0;
				}
			}else{
				map[pos.x, pos.y] = 0;
			}
			return true;
		}
			return false;	
	}
	
	bool validPosition(MyVector2 pos, int delta_x, int delta_y){
		
		int new_x = pos.x + delta_x;
		int new_y = pos.y + delta_y;
		
		if( (new_x >= 0 && new_x < MAX_X) && (new_y >= 0 && new_y < MAX_Y)) 
			return true;
		else
			return false;
		
	}
	
    MyVector2 findPos(int ID){
		
		for(int i = 0; i < 6; i++)
			for(int j = 0; j < 6; j++){
			
			if(map[i,j] == ID){
				return new MyVector2(i,j);
			}
				
		}
		
		return new MyVector2(0,0);
	}
	
	//don't ask
	public class MyVector2{
		
		public int x;
		public int y;
		
		public MyVector2(int x, int y){
			this.x = x;
			this.y = y;
		}
	}
	
}
