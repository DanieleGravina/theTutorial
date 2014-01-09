using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	Vector3 direction;
	Vector3 end_position;

	Transform platform;

	public float distance = 10f;
	public float speed = 0.5f;

	int ID;
	float weight;
	bool active = false;

	const int MAX_X = 4;
	const int MAX_Z = 4;

	public enum dirType{
		UP,
		RIGHT,
		LEFT,
		DOWN,	
	}

	dirType dir;


	// Use this for initialization
	void Start () {
		platform = this.transform.parent;
		ID = int.Parse(platform.name[0].ToString());
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
				weight=0;
				direction =platform.position - other.transform.position;
				direction.Normalize();
				if (Mathf.Abs(direction.x) <= 0.5) {
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
					end_position.x =platform.position.x;
					end_position.y = platform.position.y;
					if (direction.z > 0){
						if (updateMap(ID,0,1,dirType.DOWN)){
							active = true;
							end_position.z = platform.position.z + distance;
						}
					}else if (updateMap(ID,0,-1,dirType.UP)){
						active = true;
						end_position.z = platform.position.z - distance;
					}
				}else{
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
					end_position.y = platform.position.y;
					end_position.z = platform.position.z;
					if (direction.x > 0){
						if (updateMap(ID,-1,0,dirType.LEFT)){
							active = true;
							end_position.x = platform.position.x + distance;
						}
					}else if (updateMap(ID,1,0,dirType.RIGHT)){
						active = true;
						end_position.x = platform.position.x - distance;
					}
				}
			}
		}
	}

	bool updateMap(int ID, int delta_x, int delta_z,dirType dir){
		
		MyVector2 pos = findPos(ID);
		
		if (ID == 2){
			if (dir == dirType.DOWN){
				pos.z = pos.z + 1;
			}else if (dir == dirType.LEFT || dir == dirType.RIGHT){
				for (int i=0; i<2; i++) {
					if (!(validPosition(pos,delta_x,delta_z + i) && Globals.map[pos.z + delta_z + i,pos.x  + delta_x] == 0)){
						return false;
					}
				}
			}
		}
		
		if (validPosition(pos, delta_x, delta_z) && Globals.map[pos.z + delta_z,pos.x  + delta_x] == 0){
			Globals.map[pos.z + delta_z,pos.x + delta_x] = ID;
			if (ID == 2 && dir == dirType.DOWN){
				Globals.map[ pos.z - 1,pos.x] = 0;
			}else if (ID == 2 && dir == dirType.UP){
				Globals.map[ pos.z + 1,pos.x] = 0;
			}else if ( ID == 2 && (dir == dirType.LEFT || dir == dirType.RIGHT)){
				for (int i=0;i<2;i++){
					Globals.map[pos.z + delta_z + i,pos.x + delta_x] = ID;
					Globals.map[pos.z + i,pos.x] = 0;
				}
			}else{
				Globals.map[pos.z, pos.x] = 0;
			}
			return true;
		}
		return false;	
	}
	
	bool validPosition(MyVector2 pos, int delta_x, int delta_z){
		
		int new_x = pos.x + delta_x;
		int new_z = pos.z + delta_z;
		
		if( (new_x >= 0 && new_x < MAX_X) && (new_z >= 0 && new_z < MAX_Z)) 
			return true;
		else
			return false;
		
	}
	
	MyVector2 findPos(int ID){
		
		for(int i = 0; i < MAX_Z; i++){
			for(int j = 0; j < MAX_X; j++){
				
				if(Globals.map[i,j] == ID){
					return new MyVector2(i,j);
				}
				
			}
		}
		
		return new MyVector2(0,0);
	}
	
	//don't ask
	public class MyVector2{
		
		public int x;
		public int z;
		
		public MyVector2(int z, int x){
			this.x = x;
			this.z = z;
		}
	}
}
