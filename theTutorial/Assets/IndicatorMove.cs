using UnityEngine;
using System.Collections;

public class IndicatorMove : MonoBehaviour {
	
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
		Vector3 temp = transform.eulerAngles;
		temp.x  = 90;
		transform.eulerAngles = temp;
	}
	
}
