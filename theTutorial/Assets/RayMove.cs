using UnityEngine;
using System.Collections;

public class RayMove : MonoBehaviour {
	
	public float[] begin;
	
	public float[] end;
	
	public float length;
	
	public float speed = 6.0f;
	
	Vector3 left, right, vEndLeft, vEndRight, tempLeft, tempRight;
	
	float distance, distCovered, startTime, fracCovered;
	
	LineRenderer lineRenderer;
	RayCollider rayCollider;
	
	const int LEFT = 0;
	const int RIGHT = 1;

	// Use this for initialization
	void Start () {
		
		lineRenderer = GetComponent<LineRenderer>();
		rayCollider = GetComponent<RayCollider>();
		
		left = new Vector3(begin[0], begin[1], begin[2]);
		
		right = new Vector3(begin[0] - length, begin[1], begin[2]);
		
		lineRenderer.SetPosition(LEFT, left);
		
		lineRenderer.SetPosition(RIGHT, right);
		
		vEndLeft = new Vector3(end[0], end[1], end[2]);
		
		vEndRight = new Vector3(end[0] - length, end[1], end[2]);
		
		distance = Mathf.Abs(end[2] - begin[2]);
		
		startTime = Time.time;
	
	}
	
	// Update is called once per frame
    void Update() {
	  
		distCovered = (Time.time - startTime) * speed;
		fracCovered = distCovered / distance;
		
		tempLeft = Vector3.Lerp(left, vEndLeft, fracCovered);
		tempRight = Vector3.Lerp(right,vEndRight, fracCovered);
		
		lineRenderer.SetPosition(LEFT, tempLeft);
		lineRenderer.SetPosition(RIGHT, tempRight);
		
		rayCollider.setPosition(tempLeft, tempRight);
		
		if(fracCovered >= 1){
			startTime = Time.time;
			fracCovered = 0;
			lineRenderer.SetPosition(LEFT, left);
			lineRenderer.SetPosition(RIGHT, right);
		}
			
	}
}
