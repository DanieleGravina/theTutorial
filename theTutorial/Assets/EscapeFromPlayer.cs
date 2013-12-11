using UnityEngine;
using System.Collections;

public class EscapeFromPlayer : MonoBehaviour {
	
	public float moveSpeed = 10.0f;
	
	public GameObject[] wallPositions;
	
	float maxX, minX;
	float maxZ, minZ;
	
	float myY;
	

	// Use this for initialization
	void Start () {
		
		maxX = wallPositions[0].transform.position.x;
		minX = wallPositions[1].transform.position.x;
		
		maxZ = -wallPositions[2].transform.position.z;
		minZ = -wallPositions[3].transform.position.z;
		
		myY = transform.position.y;
	
	}
	
	// Update is called once per frame 
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player"){
		 	/*Quaternion rotation = Quaternion.LookRotation(other.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
			transform.Translate(Vector3.back*moveSpeed);*/
			float randX = Random.Range(minX, maxX);
			float randZ = Random.Range(minZ, maxZ);
			
			transform.position = new Vector3(randX, myY, randZ);
		}
	}
	
	void chekAndTranslate(){
		
		Mathf.CeilToInt(Random.Range(0,10)%2); 
	}
	
	
}
