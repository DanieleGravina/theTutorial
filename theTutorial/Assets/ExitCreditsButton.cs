using UnityEngine;
using System.Collections;

public class ExitCreditsButton : MonoBehaviour {

	void OnClick(){	
		Application.LoadLevel("InitialMenu");
	}
}
