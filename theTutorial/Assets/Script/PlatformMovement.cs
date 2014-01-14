using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	Vector3 direction;
	Vector3 end_position;

	MyVector2 pos;

	Transform platform;
	Vector3 room_position;


	public GameObject room;
	GameObject my_door1;
	GameObject my_door2;
	GameObject near_door1;
	GameObject near_door2;

	float distance = 4.6f;
	float speed = 1.5f;

	int ID;
	float weight;
	bool active = false;


	const float DELTA_Z = 151.98199f;
	const float DELTA_X = 113f;


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

//funzione che serve per andare a verificare il player da che parte spinge la piattaforma e andare a spostare
//la relativa stanza andando a settare la variabile active per non permettere ulteriori spinte mentre la piattaforma
//è in movimento
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
							room.transform.Translate(Vector3.forward * DELTA_Z);
							active = true;
							end_position.z = platform.position.z + distance;
						}
					}else if (updateMap(ID,0,-1,dirType.UP)){
						room.transform.Translate(Vector3.back * DELTA_Z);
						active = true;
						end_position.z = platform.position.z - distance;
					}
				}else{
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
					end_position.y = platform.position.y;
					end_position.z = platform.position.z;
					if (direction.x > 0){
						if (updateMap(ID,-1,0,dirType.LEFT)){
							room.transform.Translate(Vector3.right * DELTA_X);
							active = true;
							end_position.x = platform.position.x + distance;
						}
					}else if (updateMap(ID,1,0,dirType.RIGHT)){
						room.transform.Translate(Vector3.left * DELTA_X);
						active = true;
						end_position.x = platform.position.x - distance;
					}
				}
				controlPort(ID);
			}
		}
	}


//funzione per andare ad aggiornare la matrice delle stanze a seconda di quale spostamento è avvenuto
	bool updateMap(int ID, int delta_x, int delta_z, dirType dir){
		
		pos = findPos(ID);
		
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
//funzione che va a controllare se i valori dello spostamento siano possibili
	bool validPosition(MyVector2 pos, int delta_x, int delta_z){
		
		int new_x = pos.x + delta_x;
		int new_z = pos.z + delta_z;
		
		if( (new_x >= 0 && new_x < MAX_X) && (new_z >= 0 && new_z < MAX_Z)) 
			return true;
		else
			return false;
		
	}

//funzione per trovare la posizione di una stanza dato l'ID nella matrice delle stanze
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

//funzione per gestire l'apertura e la chiusura delle porte in caso di spostamento delle stanze
	void controlPort(int ID){
		pos = findPos(ID);
		switch(ID) {
			case 1:
				if (validPosition(pos,1,1)){
					if (Globals.map[pos.z,pos.x + 1] == 2 && Globals.map[pos.z + 1,pos.x + 1] == 2){
						Debug.Log("Inventory: Right door open");
						Debug.Log("Life: Left door open");
					}else{
						Debug.Log("Inventory: Right door close");
						Debug.Log("Life: Left door close");
					}
				}
				if (validPosition(pos,0,1)){
					if (Globals.map[pos.z + 1,pos.x] == 4){
						Debug.Log("Inventory: down door open");
						Debug.Log("Menù: up door open");
					}else{
						Debug.Log("Inventory: down door close");
						Debug.Log("Menù: up door close");
					}
				}
				break;
			case 2:
				if (validPosition(pos,-1,0)){
					if (Globals.map[pos.z,pos.x - 1] == 1){
						Debug.Log("Life: left door open");
						Debug.Log("Inventory: right door open");
					}else{
						Debug.Log("Life: left door close");
						Debug.Log("Inventory: right door close");
					}
				}
				if (validPosition(pos,1,1)){
					if (Globals.map[pos.z + 1,pos.x + 1] == 3){
						Debug.Log("Life: right door open");
						Debug.Log("Map: left door open");
					}else{
						Debug.Log("Life: right door close");
						Debug.Log("Map: left door close");
					}
				}
				break;
			case 3:
				if (validPosition(pos,-1,-1)){
					if (Globals.map[pos.z,pos.x - 1] == 2 && Globals.map[pos.z - 1,pos.x -1] == 2){
						Debug.Log("Map: left door open");
						Debug.Log("Life: right door open");
					}else{
						Debug.Log("Map: left door close");
						Debug.Log("Life: right door close");
					}
				}
				if (validPosition(pos,1,0)){
					if (Globals.map[pos.z,pos.x + 1] == 4){
						Debug.Log("Map: right door open");
						Debug.Log("Menu: left door open");
					}else{
					Debug.Log("Map: right door close");
					Debug.Log("Menu: left door close");
					}
				}
				
				break;
			case 4:
				if (validPosition(pos,-1,0)){
					if (Globals.map[pos.z,pos.x -1] == 3){
						Debug.Log("Menù: left door open");
						Debug.Log("Map: right door open");
					}else{
						Debug.Log("Menù: left door close");
						Debug.Log("Map: right door close");
					}
				}
				if (validPosition(pos,0,-1)){
					if (Globals.map[pos.z - 1,pos.x] == 1){
						Debug.Log("Menù: up door open");
						Debug.Log("Inventory: down door open");
					}else{
						Debug.Log("Menù: up door close");
						Debug.Log("Inventory: down door close");
					}
				}
				break;
			case 5:
				if (validPosition(pos,-1,-1)){
					if (Globals.map[pos.z,pos.x - 1] == 2 && Globals.map[pos.z - 1,pos.x - 1] == 2 ){
						Debug.Log("Timer: left door open");
						Debug.Log("Life: right door open");
					}else{
						Debug.Log("Timer: left door close");
						Debug.Log("Life: right door close");
					}
				}
				break;
		}

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
