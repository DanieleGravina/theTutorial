using UnityEngine;
using System.Collections;

public class RayMove2 : MonoBehaviour {
	
	public GameObject begin, end;
	
	public float speed = 6.0f;
	
	float distance, distCovered, startTime, fracCovered;
	
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
	
		distance = Mathf.Abs(begin.transform.position.z - end.transform.position.z);
		
		startTime = Time.time;
		
		distCovered = (Time.time - startTime) * speed;
		fracCovered = distCovered / distance;
	}
	
	// Update is called once per frame
	void Update () {
		
		distCovered = (Time.time - startTime) * speed;
		fracCovered = distCovered / distance;
		
		transform.position = Vector3.Lerp(begin.transform.position, end.transform.position, fracCovered);
		
		if(fracCovered >= 1){
			startTime = Time.time;
			fracCovered = 0;
			transform.position = begin.transform.position;
		}
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Debug.Log ("touch player");
			healthBar.GetComponent<HealthBar>().decreaseLife();
		}
	}
	

}
