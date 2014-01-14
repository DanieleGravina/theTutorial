using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour {
	
	public GameObject PhysicalTimer;
	
	public float TimeOut = 99f;
	
	public float timer;
	
	bool isCountDown = false;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isCountDown){
			timer += Time.deltaTime;
			
			guiText.text = (TimeOut - timer).ToString();
			
			if(PhysicalTimer.active){
				PhysicalTimer.GetComponent<TextMesh>().text = (TimeOut - timer).ToString();
			}
			
			if(TimeOut - timer <= 0) {
				Application.LoadLevel("Level_2");
			}
			
			if(TimeOut - timer < 10f){
				guiText.color = Color.red;
				guiText.fontSize += 1;
			}
		}
	
	}
	
	public void beginCountDown(){
		isCountDown = true;
	}
}
