using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	Vector3 direction;
	Vector3 end_position;

	MyVector2 pos;

	Transform platform;
	Vector3 room_position;

	public Material completeMaterial;
	public Material uncompleteMaterial;
	public GameObject room;

	GameObject my_door1;
	GameObject my_door2;
	GameObject near_door1;
	GameObject near_door2;
	GameObject[] platforms;
	GameObject doorSignal;

	float distance = 4.6f;
	float speed = 1f;

	int ID;
	float weight;
	bool active = false;

	const float DELTA_Z = 151.98199f;
	const float DELTA_X = 113f;

	const int MAX_X = 4;
	const int MAX_Z = 4;
	
	public static int[,] solution = new int[MAX_Z,MAX_X] {{0,0,0,0},{0,0,0,0},{0,1,2,0},{3,4,2,5}};

	public enum dirType{
		UP,
		RIGHT,
		LEFT,
		DOWN,	
	}

	dirType dir;


	// Use this for initialization
	void Start () {
		doorSignal = GameObject.Find("SignalExitDoorMap");
		platform = this.transform.parent;
		ID = int.Parse(platform.name[0].ToString());
		end_position = platform.position;
		platforms = GameObject.FindGameObjectsWithTag("platform");
		correctPlatformPosition(ID);
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

//funzione per controllare se le piattaforme sono state posizionate nella posizione corretta
	bool mapComplete(){
		for(int i = 0; i < MAX_Z; i++){
			for(int j = 0; j < MAX_X; j++){
				
				if(Globals.map[i,j] != solution[i,j] ){
				/*	foreach (GameObject temp in platforms)
					{
						temp.renderer.material = uncompleteMaterial;
					}
 				*/
					doorSignal.renderer.material = uncompleteMaterial;
					return false;
				}		
			}
		}
	/*	foreach (GameObject temp in platforms)
		{
			temp.renderer.material = completeMaterial;
		}
	*/
		doorSignal.renderer.material = completeMaterial;
		return true;

	}

	void correctPlatformPosition(int ID){
		pos = findPos(ID);
		switch (ID){
			case 1:
				if (pos.z == 2 && pos.x == 1){
					platform.gameObject.renderer.material = completeMaterial;
				}else{
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
				break;
			case 3:
				if (pos.z == 3 && pos.x == 0){
					platform.gameObject.renderer.material = completeMaterial;
				}else{
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
				break;
			case 4:
				if (pos.z == 3 && pos.x == 1){
					platform.gameObject.renderer.material = completeMaterial;
				}else{
					platform.gameObject.renderer.material = uncompleteMaterial;
				}
				break;
			case 5:
				if (pos.z == 3 && pos.x == 3){
					platform.gameObject.renderer.material = completeMaterial;
				}else{
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
