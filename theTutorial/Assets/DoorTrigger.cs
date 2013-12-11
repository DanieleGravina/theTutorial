using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	
	public GameObject door;
	
	public Level levelDoor;
	
	public float speed = 3.0F;
	
	const float translate = -4f;
	
	Vector3 start, end;
	
	float distance, distCovered, startTime, fracCovered;
	
	bool openDoor = false;
	
	

	// Use this for initialization
	void Start () {
		
		start = door.transform.position;
		end = new Vector3(start.x + translate, start.y, start.z);
		distance = -translate;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(openDoor){
			distCovered = (Time.time - startTime) * speed;
			fracCovered = distCovered / distance;
			door.transform.position = Vector3.Lerp(start, end, fracCovered);
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Debug.Log(Globals.currentLevel);
			if(levelDoor == Globals.currentLevel){
				openDoor = true;
				startTime = Time.time;
			}
		}
	}
}
