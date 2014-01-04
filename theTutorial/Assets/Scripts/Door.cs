using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool open=false;
	public bool close=false;
	public bool right;
	public float speed_open;
	Vector3 initial;
	// Use this for initialization
	void Start () {
		initial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!right)
		{
			
			//Open the door
			if(open)
			{
                transform.position = transform.position + new Vector3(-speed_open,0,0);
				
			}
			if(transform.position.x  - initial.x < -2.2)
			{
				open=false;
			}
			
			
			//Close the door
			if(close)
			{
				Debug.Log("Chiudi");
				transform.position = transform.position + new Vector3(speed_open,0,0);
				
			}
			if(transform.position.x  - initial.x > 0)
			{
				close=false;
			}
			
			
			
		}else
		{
			//Open the door
			if(open)
			{
				transform.position = transform.position + new Vector3(speed_open,0,0);
				
			}
			if(transform.position.x  - initial.x > 2.2)
			{
				open=false;
			}
			
			
			//Close the door
			if(close)
			{
				Debug.Log("Chiudi");
				transform.position = transform.position + new Vector3(-speed_open,0,0);
				
			}
			if(transform.position.x  - initial.x < 0)
			{
				close=false;
			}
		}
	}
}
