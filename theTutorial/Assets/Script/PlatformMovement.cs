using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	Vector3 direction;
	Vector3 end_position;

	Transform platform;

	public float distance = 10f;
	public float speed = 0.5f;
	public 	int ID;

	float weight;
	bool active = false;

	const int MAX_X = 4;
	const int MAX_Y = 4;
	
	int[,] map = new int[MAX_X,MAX_Y];


	// Use this for initialization
	void Start () {

		map[1,1] = 1;
		map[2,0] = 5;
		map[2,1] = 4;
		map[2,3] = 3;

		map[1,2] = 2;
		map[2,2] = 2;
		
		platform = this.transform.parent;
		end_position = platform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (active == true){
			weight += Time.deltaTime*speed;
			if (weight > 1) {
				active = false;
			}
			platform.position = Vector3.Lerp(platform.position,end_position,weight/distance);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			if (active == false){
				direction =platform.position - other.transform.position;
				direction.Normalize();
				active = true;
				if (Mathf.Abs(direction.x) <= 0.5) {
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
					end_position.x =platform.position.x;
					end_position.y = platform.position.y;
					if (direction.z > 0){
						if (updateMap(ID,0,1)){
							active = true;
							end_position.z = platform.position.z + distance;
						}
					}else if (updateMap(ID,0,-1)){
						active = true;
						end_position.z = platform.position.z - distance;
					}
				}else{
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
					end_position.y = platform.position.y;
					end_position.z = platform.position.z;
					if (direction.x > 0){
						if (updateMap(ID,-1,0)){
							active = true;
							end_position.x = platform.position.x + distance;
						}
					}else if (updateMap(ID,1,0)){
						active = true;
						end_position.x = platform.position.x - distance;
					}
				}
			}
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
		
		for(int i = 0; i < MAX_X; i++){
			for(int j = 0; j < MAX_Y; j++){
				
				if(map[i,j] == ID)
					return new MyVector2(i,j);
				
			}
		}
		return new MyVector2(0,0);
	}

	public class MyVector2{
		
		public int x;
		public int y;
		
		public MyVector2(int x, int y){
			x = x;
			y = y;
		}


	}

}



