using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	Vector3 direction;
	Vector3 end_position;
	Vector3 start_position;
	Vector3 tempPlatformPos;
	Vector3 tempRoomPos;

	MyVector2 pos;

	Transform platform;

	public Material completeMaterial;
	public Material uncompleteMaterial;
	public GameObject room;

	GameObject my_door1;
	GameObject my_door2;
	GameObject near_door1;
	GameObject near_door2;
	GameObject[] platforms;
	GameObject[] platformsPosition;
	GameObject[] roomsPosition;


	public GameObject doorSignal;
	public GameObject StateLevel;

	float distance = 4.6f/2;
	float speed = 2f;

	int ID;
	float weight;
	bool active = false;
	public static bool enable = false;

	int contx = 0;
	int contz = 0;

	const float DELTA_Z = 151.98199f/2;
	const float DELTA_X = 113f/2;

	const int MAX_X = 4;
	const int MAX_Z = 4;
	
	int[,] solution = new int[MAX_Z,MAX_X] {{0,0,0,0},{0,0,0,0},{0,1,2,0},{3,4,2,5}};

	public enum dirType{
		UP,
		RIGHT,
		LEFT,
		DOWN,
		NULL
	}

	dirType dir;


	// Use this for initialization
	void Start () {
		Globals.map =  new int[MAX_Z,MAX_X] {{0,0,0,0},{0,1,2,0},{5,4,2,3},{0,0,0,0}};
		platform = this.transform;
		ID = int.Parse(platform.name[0].ToString());
		end_position = platform.position;
		platforms = GameObject.FindGameObjectsWithTag("platform");
		platformsPosition = GameObject.FindGameObjectsWithTag("platformPosition");
		roomsPosition = GameObject.FindGameObjectsWithTag("roomPosition");
		correctPlatformPosition(ID);
	}
	
	// Update is called once per frame
	void Update () {
		if (active == true){
			weight += Time.deltaTime*speed;
			if (weight > 1) {
				active = false;
			}
			platform.position = Vector3.Lerp(start_position,end_position,weight);
		}

		/*if (Input.GetKey(KeyCode.R) && enable == true){
			Globals.map =  new int[MAX_Z,MAX_X] {{0,0,0,0},{0,1,2,0},{5,4,2,3},{0,0,0,0}};
			foreach (GameObject obj in platformsPosition){
				if (int.Parse(obj.name[0].ToString()) == ID){
					tempPlatformPos.x = obj.transform.position.x;
					tempPlatformPos.y = obj.transform.position.y;
					tempPlatformPos.z = obj.transform.position.z;
					break;
				}
			}
			foreach (GameObject obj in roomsPosition){
				if (int.Parse(obj.name[0].ToString()) == ID){
					tempRoomPos.x = obj.transform.position.x;
					tempRoomPos.y = obj.transform.position.y;
					tempRoomPos.z = obj.transform.position.z;
					break;
				}
			}
				platform.transform.position = tempPlatformPos;
				room.transform.position = tempRoomPos;
		} */
	}

//funzione che serve per andare a verificare il player da che parte spinge la piattaforma e andare a spostare
//la relativa stanza andando a settare la variabile active per non permettere ulteriori spinte mentre la piattaforma
//è in movimento
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Player"){
			if (active == false){
				pos = findPos(ID);
				weight=0;
				direction =platform.position - collision.collider.transform.position;
				direction.Normalize();
				if (Mathf.Abs(direction.x) <= 0.5) {
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
					end_position.x = platform.position.x;
					end_position.y = platform.position.y;
					if (direction.z > 0){
						if (System.Math.Abs(contx) != 1 && validPosition(pos,0,1) && updateMap(ID,0,1,dirType.DOWN)){
							contz++;
						}
						if (contz == -1){
							contz++;
							room.transform.Translate(Vector3.forward * DELTA_Z);
							start_position = platform.position;
							active = true;
							end_position.z = platform.position.z + distance;
						}
						if (updateMap(ID,0,1,dirType.DOWN)){
							room.transform.Translate(Vector3.forward * DELTA_Z);
							start_position = platform.position;
							active = true;
							end_position.z = platform.position.z + distance;
						}
					}else{
						if (System.Math.Abs(contx) != 1 && validPosition(pos,0,-1) && updateMap(ID,0,-1,dirType.UP)){
							contz--;
						}
						if (contz == 1){
							contz--;
							room.transform.Translate(Vector3.back * DELTA_Z);
							start_position = platform.position;
							active = true;
							end_position.z = platform.position.z - distance;
						}
						if (updateMap(ID,0,-1,dirType.UP)){
		
							room.transform.Translate(Vector3.back * DELTA_Z);
							start_position = platform.position;
							active = true;
							end_position.z = platform.position.z - distance;
						}
					}
				}else{
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
					end_position.y = platform.position.y;
					end_position.z = platform.position.z;
					if (direction.x > 0){
						if (System.Math.Abs(contz) != 1 && validPosition(pos,-1,0) && updateMap(ID,-1,0,dirType.LEFT)){
							contx--;
						}
						if (contx == 1){
							contx--;
							room.transform.Translate(Vector3.right * DELTA_X);
							start_position = platform.position;
							active = true;
							end_position.x = platform.position.x + distance;
						}
						if (updateMap(ID,-1,0,dirType.LEFT)){
							room.transform.Translate(Vector3.right * DELTA_X);
							start_position = platform.position;
							active = true;
							end_position.x = platform.position.x + distance;
						}
					}else{
						if (System.Math.Abs(contz) != 1 && validPosition(pos,1,0) && updateMap(ID,1,0,dirType.RIGHT)){
							contx++;
						}
						if (contx == -1){
							contx++;
							room.transform.Translate(Vector3.left * DELTA_X);
							start_position = platform.position;
							active = true;
							end_position.x = platform.position.x - distance;
						}
						if (updateMap(ID,1,0,dirType.RIGHT)){
							room.transform.Translate(Vector3.left * DELTA_X);
							start_position = platform.position;
							active = true;
							end_position.x = platform.position.x - distance;
						}
					}
				}
				mapComplete();
				correctPlatformPosition(ID);
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
					pos.z = pos.z + i;
					if (!(validPosition(pos,delta_x,delta_z) && Globals.map[pos.z + delta_z,pos.x  + delta_x] == 0)){
						return false;
					}
				}
				pos.z = pos.z - 1;
			}
		}
		
		if (validPosition(pos, delta_x, delta_z) && Globals.map[pos.z + delta_z,pos.x  + delta_x] == 0){
			if (System.Math.Abs(contx) == 2 || System.Math.Abs(contz) == 2){
				Globals.map[pos.z + delta_z,pos.x + delta_x] = ID;
			}
			if (ID == 2 && dir == dirType.DOWN){
				if (System.Math.Abs(contx) == 2 || System.Math.Abs(contz) == 2){
					Globals.map[ pos.z - 1,pos.x] = 0;
					contx = 0;
					contz = 0;
				}
			}else if (ID == 2 && dir == dirType.UP){
				if (System.Math.Abs(contx) == 2 || System.Math.Abs(contz) == 2){
					Globals.map[ pos.z + 1,pos.x] = 0;
					contx = 0;
					contz = 0;
				}
			}else if ( ID == 2 && (dir == dirType.LEFT || dir == dirType.RIGHT)){
				if (System.Math.Abs(contx) == 2 || System.Math.Abs(contz) == 2){
					for (int i=0;i<2;i++){
						Globals.map[pos.z + delta_z + i,pos.x + delta_x] = ID;
						Globals.map[pos.z + i,pos.x] = 0;
					}
					contx = 0;
					contz = 0;
				}
			}else{
				if (System.Math.Abs(contx) == 2 || System.Math.Abs(contz) == 2){
					Globals.map[pos.z, pos.x] = 0;
					contx = 0;
					contz = 0;
				}
			}
			return true;
		}
		return false;	
	}
//funzione che va a controllare se i valori dello spostamento siano possibili
	bool validPosition(MyVector2 pos, int delta_x, int delta_z){

		if (System.Math.Abs(contx) == 1 && System.Math.Abs(delta_z) == 1){
			return false;
		}else if (System.Math.Abs(contz) == 1 && System.Math.Abs(delta_x) == 1){
			return false;
		}
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

//funzione per controllare se le piattaforme sono state posizionate nella posizione corretta
	bool mapComplete(){
		for(int i = 0; i < MAX_Z; i++){
			for(int j = 0; j < MAX_X; j++){
				if(Globals.map[i,j] != solution[i,j] ){
					//doorSignal.GetComponent<SignalColorManager>().ChangeSignalColor();
					return false;
				}		
			}
		}
		if (System.Math.Abs(contx) != 1 && System.Math.Abs(contz) != 1){
			doorSignal.GetComponent<SignalColorManager>().ChangeSignalColor();
			StateLevel.GetComponent<StateLevel>().openAllDoor();
			return true;
		}
		//doorSignal.GetComponent<SignalColorManager>().ChangeSignalColor();
		return false;

	}

//funzione per cambiare colore alle piattaforme che si trovano nella corretta posizione
/*
0,0,0,0
0,0,0,0
0,1,2,0
3,4,2,5
0,0,0,0*/
	void correctPlatformPosition(int ID){
		pos = findPos(ID);
		switch (ID){
			case 1:
				if (pos.z == 2 && pos.x == 1){
					platform.gameObject.renderer.material = completeMaterial;
				}else{
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
			if ((System.Math.Abs(contx) == 1 || System.Math.Abs(contz) == 1) && platform.gameObject.renderer.material.name == "yellow (Instance)"){
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
				break;
			case 2:
				if (pos.z == 2 && pos.x == 2 && Globals.map[pos.z + 1,pos.x] == 2){
					platform.gameObject.renderer.material = completeMaterial;
				}
				else{
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
			if ((System.Math.Abs(contx) == 1 || System.Math.Abs(contz) == 1) && platform.gameObject.renderer.material.name == "yellow (Instance)"){
					platform.gameObject.renderer.material = uncompleteMaterial;
			}
				break;
			case 3:
				if (pos.z == 3 && pos.x == 0){
					platform.gameObject.renderer.material = completeMaterial;
				}else{
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
			if ((System.Math.Abs(contx) == 1 || System.Math.Abs(contz) == 1) && platform.gameObject.renderer.material.name == "yellow (Instance)"){
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
				break;
			case 4:
				if (pos.z == 3 && pos.x == 1){
					platform.gameObject.renderer.material = completeMaterial;
				}else{
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
			if ((System.Math.Abs(contx) == 1 || System.Math.Abs(contz) == 1) && platform.gameObject.renderer.material.name == "yellow (Instance)"){
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
				break;
			case 5:
				if (pos.z == 3 && pos.x == 3){
					platform.gameObject.renderer.material = completeMaterial;
				}else{
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
			if ((System.Math.Abs(contx) == 1 || System.Math.Abs(contz) == 1) && platform.gameObject.renderer.material.name == "yellow (Instance)"){
					platform.gameObject.renderer.material = uncompleteMaterial;
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
