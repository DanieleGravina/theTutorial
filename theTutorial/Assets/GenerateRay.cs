using UnityEngine;
using System.Collections;

public class GenerateRay : MonoBehaviour {
	
	public float deltaTime;
	
	public GameObject ray;
	
	public int MaxRays = 5;
	
    int counter = 0;
	
	float timer;

	// Use this for initialization
	void Start () {
	
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		
		if(timer >= deltaTime && counter < MaxRays){
			
			Instantiate(ray);
			counter++;
			
			timer = 0f;
		}
	
	}
}
