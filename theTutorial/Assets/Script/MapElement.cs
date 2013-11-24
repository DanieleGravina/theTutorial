using UnityEngine;
using System.Collections;


public class MapElement:MonoBehaviour
{
	GameObject room, guiElement;
	
	public MapElement (GameObject room, GameObject guiElement)
	{
		room = room;
		
		guiElement = guiElement;
	}
}


