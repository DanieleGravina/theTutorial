using UnityEngine;
using System.Collections;

public class LifeMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localScale.x > 0){
			transform.localScale += new Vector3(-0.1F, 0, 0);
			transform.Translate(-3, 0,0); 
		}
	}
	
	public void ReduceLife(){
		if(transform.localScale.x > 0){
			transform.localScale += new Vector3(-0.1F, 0, 0);
			transform.Translate(-3, 0,0); 
		}
	}
	
	public void RestoreLife(){
		if(transform.localScale.x < 1){
			transform.localScale += new Vector3(0.1F, 0, 0);
			transform.Translate(3, 0,0); 
		}
	}
		
}
