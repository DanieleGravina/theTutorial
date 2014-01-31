using UnityEngine;
using System.Collections;

public class ExitCreditsButton : MonoBehaviour {

	void Update(){

		if(Input.GetKey(KeyCode.Escape)){

			Application.LoadLevel("InitialMenu");
		}
	}
}
