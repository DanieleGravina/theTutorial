using UnityEngine;
using System.Collections;

public class CharacterSound : MonoBehaviour {
	public GameObject jumpSound;
	Collider old = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "floor"){
			if (old.Equals(collision.collider)){
				jumpSound.audio.Play();
			}
			old = collision.collider;
		}
	}
}
