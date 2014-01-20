using UnityEngine;
using System.Collections;

public enum doorDirection{
	X,
	Z
}

public class DoorTrigger : MonoBehaviour {
	
	enum stateDoor{
		OPEN,
		CLOSED
	}
	
	stateDoor state = stateDoor.CLOSED;
	
	public GameObject door, GUIdialog;
	
	public string[] text;
	
	public Level levelDoor;
	
	public GameObject StateLevel;
	
	public doorDirection dirDoor = doorDirection.X;
	
	public float speed = 3.0F;
	
	const float translate = -4f;
	
	Vector3 start, end;
	
	float distance, distCovered, startTime, fracCovered;
	
	bool openDoor, closeDoor = false;
	
	

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
		
		GUIdialog = GameObject.Find("GUI Text");
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(openDoor){
			distCovered = (Time.time - startTime) * speed;
			fracCovered = distCovered / distance;
			door.transform.position = Vector3.Lerp(start, end, fracCovered);
			
			if(fracCovered >= 1f)
				openDoor = false;
		}
		
		if(closeDoor){
			distCovered = (Time.time - startTime) * speed;
			fracCovered = distCovered / distance;
			door.transform.position = Vector3.Lerp(end, start, fracCovered);
			
			if(fracCovered >= 1f)
				closeDoor = false;
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && state == stateDoor.CLOSED){
			
			float translateX = 0f, translateZ = 0f;
			
			if(start != door.transform.position){
		
				if(dirDoor == doorDirection.X)
					translateX = translate;
				else
					translateZ = translate;
				
				start = door.transform.position;
				end = new Vector3(start.x + translateX, start.y, start.z + translateZ);
			}
			
			if(levelDoor == StateLevel.GetComponent<StateLevel>().CurrentLevel || 
				levelDoor == Level.ALL){
				state = stateDoor.OPEN;
				openDoor = true;
				startTime = Time.time;
				door.audio.Play();
			}
			else{
				GUIdialog.GetComponent<GUITextManager>().WriteOutputOnGUI(text);
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag == "Player" && state == stateDoor.OPEN){
			state = stateDoor.CLOSED;
			closeDoor = true;
			startTime = Time.time;
			door.audio.Play();
		}
	}
}
