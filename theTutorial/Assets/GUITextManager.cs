using UnityEngine;
using System.Collections;

public class GUITextManager : MonoBehaviour {
	
	bool onWriting = true;
	
	public float delay = 0.07f;
	float actualDelay;
	
	string[] buffer;
	int textPos = 0;

	// Use this for initialization
	void Start () {
		
		actualDelay = delay;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonUp(0)){
			
			if(onWriting){
				actualDelay = 0;
			}
			else
				if(buffer != null && textPos < buffer.Length)
				{
						guiText.text = "";
						actualDelay = delay;
						write();
						textPos++;
						onWriting = true;
				}
		}
	
	}
	
	void write(){
		StartCoroutine(PokeText(buffer[textPos]));
	}
	
	public void WriteOutputOnGUI(string[] text){
		
		buffer = text;
		textPos = 0;
		guiText.text = "";
		write ();
		textPos++;
	}
	
	 IEnumerator PokeText(string t)
    {
		
        for (int i = 0; i < t.Length; i++)
        {

            guiText.text += t.ToCharArray()[i];

            yield return new WaitForSeconds(delay);
        }
		onWriting = false;
    }

     
}
