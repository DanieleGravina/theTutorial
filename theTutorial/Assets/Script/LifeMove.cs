using UnityEngine;
using System.Collections;

public class LifeMove : MonoBehaviour {
	
	float DELTA_LIFE = 0.1f;

	// Use this for initialization
	void Start () {
		
		if(Globals.life < 99){
			
			for(int i = Globals.life; i < 99; i += 11){
				ReduceLife();
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ReduceLife(){
		if(transform.localScale.x > 0){
			transform.localScale += new Vector3(-DELTA_LIFE, 0, 0);
			transform.Translate(-3, 0,0); 
		}
	}
	
	public void RestoreLife(){
		if(transform.localScale.x < 1){
			transform.localScale += new Vector3(DELTA_LIFE, 0, 0);
			transform.Translate(3, 0,0); 
		}
	}
		
}
