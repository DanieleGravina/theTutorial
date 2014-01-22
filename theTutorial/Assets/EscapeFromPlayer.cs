using UnityEngine;
using System.Collections;

public class EscapeFromPlayer : MonoBehaviour {
	
	public float moveSpeed = 10.0f;
	
	public GameObject[] wallPositions;
	
	public GameObject player;
	
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
		
		player = GameObject.Find("RigidbodyController");
	
	}
	
	// Update is called once per frame 
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player"){
		 	
			Vector3 newPos;
			
			float randX = Random.Range(minX, maxX);
			float randZ = Random.Range(minZ, maxZ);
			
			newPos = new Vector3(randX, myY, randZ);
			
			while(player.transform.position.x == newPos.x && player.transform.position.z == newPos.z){
				randX = Random.Range(minX, maxX);
				randZ = Random.Range(minZ, maxZ);
			
				newPos = new Vector3(randX, myY, randZ);
			}
			
			transform.GetChild(0).GetComponent<ArrowMove>().follow(randX, randZ);
				
			transform.position = newPos;
		}
	}
	
	void chekAndTranslate(){
		
		Mathf.CeilToInt(Random.Range(0,10)%2); 
	}
	
	
}
