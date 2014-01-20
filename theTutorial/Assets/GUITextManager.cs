using UnityEngine;
using System.Collections;

public class GUITextManager : MonoBehaviour {
	
	public GameObject player;
	
	Player playerScript;
	
	bool onWriting = true;
	
	bool beginWrite = false;
	
	public float delay = 0.07f;
	float actualDelay;
	
	string[] buffer;
	int textPos, index = 0;
	
	float timer;

	// Use this for initialization
	void Start () {
		
		actualDelay = delay;
		
		timer = 0;
		
		index = 0;
		
		playerScript = player.GetComponent<Player>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonUp(0)){
			
			if(onWriting){
				actualDelay = 0;
			}
			else
				if(buffer != null && textPos < (buffer.Length - 1) )
				{
						guiText.text = "";
						actualDelay = delay;
						textPos++;
						index = 0;
						onWriting = true;
						beginWrite= true;
				}
		}
		
		if(beginWrite && guiText != null && buffer != null && buffer[textPos] != null){
			timer += Time.deltaTime;
			
			if(timer >= actualDelay){
				
				guiText.text += buffer[textPos].ToCharArray()[index];
				timer = 0;
				index++;
				
				if(index == buffer[textPos].Length){
					beginWrite = false;
					index = 0;
					onWriting = false;
				}
				
				if(textPos == buffer.Length){
					beginWrite = false;
					index = 0;
					onWriting = false;
				}
				
				if(textPos == buffer.Length - 1)
					playerScript.FreePlayer();
				
			}
		}
	
	}
	
	public void WriteOutputOnGUI(string[] text){
		
		buffer = text;
		textPos = 0;
		index = 0;
		guiText.text = "";
		onWriting = true;
		actualDelay = delay;
		beginWrite = true;
		if(!Globals.CountDownOn)
			playerScript.BlockPlayer();
	}
	
	/* IEnumerator PokeText(string t)
    {
		
        for (int i = 0; i < t.Length; i++)
        {

            guiText.text += t.ToCharArray()[i];

            yield return new WaitForSeconds(delay);
        }
		onWriting = false;
    }*/

     
}
