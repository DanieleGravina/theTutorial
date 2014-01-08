using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	Vector3 direction;
	Vector3 end_position;
	Transform platform;
	public float distance = 10f;
	public float speed = 0.5f;
	float weight;
	bool active = false;

	// Use this for initialization
	void Start () {
		platform = this.transform.parent;
		end_position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
			weight += Time.deltaTime*speed;
			if (weight > 1) {
				active = false;
			}
			platform.position = Vector3.Lerp(this.transform.position,end_position,weight/distance);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			if (active == false){
				active = true;
				direction = this.transform.position - other.transform.position;
				direction.Normalize ();
				Debug.Log(direction);
				if (Mathf.Abs(direction.x) <= 0.5) {
					weight = 0;
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
					end_position.x = this.transform.position.x;
					end_position.y = this.transform.position.y;
					if (direction.z > 0){
						end_position.z = this.transform.position.z + distance;
					}else{
						end_position.z = this.transform.position.z - distance;
					}
				}else{
					weight = 0;
					platform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
					if (direction.x > 0){
						end_position.x = this.transform.position.x + distance;
					}else{
						end_position.x = this.transform.position.x - distance;
					}
					end_position.y = this.transform.position.y;
					end_position.z = this.transform.position.z;
				}
			}
		}
	}
}


