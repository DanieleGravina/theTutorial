using UnityEngine;
using System.Collections;

public class GenerateRay : MonoBehaviour {
	
	public float deltaTime;
	
	public GameObject ray;
	
	float timer;

	// Use this for initialization
	void Start () {
	
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		
		if(timer >= deltaTime){
			Instantiate(ray);
			timer = 0f;
		}
	
	}
}
