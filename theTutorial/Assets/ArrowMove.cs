using UnityEngine;
using System.Collections;

public class ArrowMove : MonoBehaviour {
	
	public float speed = 1.0F;
	
	const float translate = 0.5f;
	
	Vector3 start, end, temp;
	
	float distance, distCovered, startTime, fracCovered;
	
	bool openDoor = false;

	// Use this for initialization
	void Start () {
		
		start = transform.position;
		end = new Vector3(start.x, start.y + translate, start.z);
		distance = translate;
		startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		distCovered = (Time.time - startTime) * speed;
		fracCovered = distCovered / distance;
	    transform.position = Vector3.Lerp(start, end, fracCovered);
		
		if(transform.position == end){
			startTime = Time.time;
			temp = end;
			end = start;
			start = temp;
			distCovered = 0f;
			fracCovered = 0f;
		}
	
	}
	
	public void follow(float x, float z){
		transform.position = new Vector3(x, transform.position.y, z);
		start = transform.position;
		end = new Vector3(start.x, start.y + translate, start.z);
		distance = translate;
		startTime = Time.time;
	}
}
