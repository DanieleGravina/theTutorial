using UnityEngine;
using System.Collections;

public enum letter{
	LEFT, RIGHT
}

public class GenerateLetters : MonoBehaviour {
	
	public GameObject LetterLeft;
	public GameObject LetterRight;
	
	GameObject tmp;
	Transform dialog;
	
	letter nextLetter = letter.RIGHT;
	
	Vector3 initialPositionLetterRight;
	Vector3 initialPositionLetterLeft;
	
	public int counter = 10;
	
	public float timeOut = 2f;
	
	float timer = 0.0f;
	
	// Use this for initialization
	void Start () {
		dialog = GameObject.Find("7_Dialog").GetComponent<Transform>();
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
				tmp = Instantiate(LetterLeft, initialPositionLetterLeft, Quaternion.identity) as GameObject;
				nextLetter = letter.RIGHT;
			}else{
				tmp = Instantiate(LetterRight, initialPositionLetterRight, Quaternion.identity) as GameObject;
				nextLetter = letter.LEFT;
			}
			
			tmp.transform.parent = dialog;
			
		}
	
	}
}
