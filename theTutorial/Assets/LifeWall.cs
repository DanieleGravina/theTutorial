using UnityEngine;
using System.Collections;

public class LifeWall : MonoBehaviour {
	
	public float DELTA_LIFE = 10f;
	
	public float TRANSLATE = 5f;
	
	Vector3 initialScale, initialPosition;

	// Use this for initialization
	void Start () {
		
		initialPosition = transform.localPosition;
		initialScale = transform.localScale;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void decreaseLifeWall(){
		
		if(transform.localScale.x > 0){
			transform.localScale += new Vector3(0, 0, -DELTA_LIFE);
			transform.Translate(0, 0, TRANSLATE); 
		}
		
	}
	
	public void increaseLifeWall(){
		
		if(transform.localScale.x <= initialScale.x){
			transform.localScale += new Vector3(0, 0, DELTA_LIFE/2);
			transform.Translate(0, 0, -TRANSLATE/2); 
		}
	}
	
	public void changeColorWall(Color color){
		
		renderer.material.color = color;
	}
	
	public void restoreSize(){
		
		transform.localPosition = initialPosition;
		transform.localScale = initialScale;
	}
}

