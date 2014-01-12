using UnityEngine;
using System.Collections;

public enum doorDirection{
	X,
	Z
}

public class DoorTrigger : MonoBehaviour {
	
	public GameObject door;
	
	public Level levelDoor;
	
	public GameObject StateLevel;
	
	public doorDirection dirDoor = doorDirection.X;
	
	public float speed = 3.0F;
	
	const float translate = -4f;
	
	Vector3 start, end;
	
	float distance, distCovered, startTime, fracCovered;
	
	bool openDoor = false;
	
	

	// Use this for initialization
	void Start () {
		
		float translateX = 0f, translateZ = 0f;
		
		if(dirDoor == doorDirection.X)
			translateX = translate;
		else
			translateZ = translate;
		
		start = door.transform.position;
		end = new Vector3(start.x + translateX, start.y, start.z + translateZ);
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
			Debug.Log(StateLevel.GetComponent<StateLevel>().CurrentLevel);
			if(levelDoor == StateLevel.GetComponent<StateLevel>().CurrentLevel){
				openDoor = true;
				startTime = Time.time;
				door.audio.Play();
			}
		}
	}
}
