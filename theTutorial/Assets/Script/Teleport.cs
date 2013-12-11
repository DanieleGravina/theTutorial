using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	GameObject player;
	Transform target_teleport1;
	Transform target_teleport2;
	Transform room;
	Transform my_teleport1;
	Transform my_teleport2;
	bool first = true;
	bool active = false;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		room = this.transform.parent.transform.parent;
		if (room.name == "4_Menu"){
			my_teleport1 = room.transform.FindChild("teleport1").FindChild("teleport1_trigger");
		}else if (room.name == "1_Esc"){
			my_teleport2 = room.transform.FindChild("teleport2").FindChild("teleport2_trigger");
		}else{
			my_teleport1 = room.transform.FindChild("teleport1").FindChild("teleport1_trigger");
			my_teleport2 = room.transform.FindChild("teleport2").FindChild("teleport2_trigger");
		}
		switch (room.name){
			case "7_Dialog":
				if (first){
					first = false;
					active = true;
				}
				target_teleport1 = GameObject.Find("6_Map").transform.FindChild("teleport1");
				target_teleport2 = GameObject.Find("3_Life").transform.FindChild("teleport2");
				break;
			case "6_Map":
				target_teleport1 = GameObject.Find("5_Inventory").transform.FindChild("teleport1");
				target_teleport2 = GameObject.Find("7_Dialog").transform.FindChild("teleport2");
				break;
			case "5_Inventory":
				target_teleport1 = GameObject.Find("4_Menu").transform.FindChild("teleport1");
				target_teleport2 = GameObject.Find("6_Map").transform.FindChild("teleport2");
				break;
			case "4_menu":
				target_teleport2 = GameObject.Find("5_Inventory").transform.FindChild("teleport2");
				break;
			case "3_Life":
				target_teleport1 = GameObject.Find("7_Dialog").transform.FindChild("teleport1");
				target_teleport2 = GameObject.Find("2_Timer").transform.FindChild("teleport2");
				break;
			case "2_Timer":
				target_teleport1 = GameObject.Find("3_Life").transform.FindChild("teleport1");
				target_teleport2 = GameObject.Find("1_Esc").transform.FindChild("teleport2");
				break;
			case "1_Esc":
				target_teleport1 = GameObject.Find("2_Timer").transform.FindChild("teleport1");
				break;
		}		
	}
	
	// Update is called once per frame
	void Update () {	
	}
	
	void OnTriggerEnter (Collider other) {	
		if (other.tag == "Player"){
			if (active){
				if (this.name == "teleport2_trigger"){
					player.transform.position = target_teleport1.position;
				}else{
					player.transform.position = target_teleport2.position;
				}
			}
		}
	}
	
	void OnTriggerExit (Collider other) {	
		if (other.tag == "Player"){
			if (active){
				active = false;
			}else{
				if (room.name == "4_Menu"){
					my_teleport1.GetComponent<Teleport>().active = true;
				}else if (room.name == "1_Esc"){
					my_teleport2.GetComponent<Teleport>().active = true;
				}else{
					my_teleport1.GetComponent<Teleport>().active = true;
					my_teleport2.GetComponent<Teleport>().active = true;	
				}
			}
		}
	}
}
