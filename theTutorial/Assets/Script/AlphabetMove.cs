using UnityEngine;
using System.Collections;

public class AlphabetMove : MonoBehaviour {

	public int velocity = 10;
	
	float translation;
	
	float deltaTime;
	
	Vector3 initial_pos;
	
	float timer = 0.0f;
	
	// Use this for initialization
	void Start () {
		initial_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		deltaTime = Time.deltaTime;
		
		timer += 1*deltaTime;
		
		if(timer >= 5f){
			timer = 0f;
			Instantiate(this.gameObject, initial_pos, Quaternion.identity);
		}
		
		if(transform.position.x <= - 83)
			Destroy(this.gameObject);
		
		
		translation = deltaTime * velocity;
        transform.Translate(-translation, 0, 0);
	
	}
}
