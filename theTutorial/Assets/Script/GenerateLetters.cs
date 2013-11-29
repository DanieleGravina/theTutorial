using UnityEngine;
using System.Collections;

public enum letter{
	LEFT, RIGHT
}

public class GenerateLetters : MonoBehaviour {
	
	public GameObject LetterLeft;
	public GameObject LetterRight;
	
	letter nextLetter = letter.RIGHT;
	
	Vector3 initialPositionLetterRight;
	Vector3 initialPositionLetterLeft;
	
	public int counter = 10;
	
	public float timeOut = 2f;
	
	float timer = 0.0f;
	
	// Use this for initialization
	void Start () {
	
		initialPositionLetterLeft = LetterLeft.transform.position;
		initialPositionLetterRight = LetterRight.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		
		if ( counter > 0  && timer >= timeOut){
			timer = 0.0f;
			counter--;
			
			if(nextLetter == letter.LEFT){
				Instantiate(LetterLeft, initialPositionLetterLeft, Quaternion.identity);
				nextLetter = letter.RIGHT;
			}else{
				Instantiate(LetterRight, initialPositionLetterRight, Quaternion.identity);
				nextLetter = letter.LEFT;
			}
			
		}
	
	}
}
