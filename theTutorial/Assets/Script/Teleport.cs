using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	GameObject player;
	Transform target_teleport1;
	Transform target_teleport2;
	Transform room;
	Transform my_teleport1;
	Transform my_teleport2;
	Transform my_teleport3;
	Transform my_teleport4;
	bool first = true;
	bool active = false;
	Transform map;
	
	// Use this for initialization
	void Start () {
		map = GameObject.Find("6_Map").GetComponent<Transform>();
		map.FindChild("4_platform").FindChild("MovementTrigger").GetComponent<HUDPosition>().active = Globals.active_menu_platform;
		player = GameObject.FindWithTag("Player");
		room = this.transform.parent.transform.parent;
//a seconda della stanza in cui sono vado a prendere i teletrasporti presenti
		if (room.name == "4_Menu"){
			my_teleport1 = room.transform.FindChild("teleport1").FindChild("teleport1_trigger");
		}else if (room.name == "1_Esc"){
			my_teleport2 = room.transform.FindChild("teleport2").FindChild("teleport2_trigger");
		}else if (room.name == "7_Dialog"){
			my_teleport1 = room.transform.FindChild("teleport1").FindChild("teleport1_trigger");
			my_teleport2 = room.transform.FindChild("teleport2").FindChild("teleport2_trigger");
			my_teleport3 = room.transform.FindChild("teleport3").FindChild("teleport3_trigger");
			my_teleport4 = room.transform.FindChild("teleport4").FindChild("teleport4_trigger");
		}else{
			my_teleport1 = room.transform.FindChild("teleport1").FindChild("teleport1_trigger");
			my_teleport2 = room.transform.FindChild("teleport2").FindChild("teleport2_trigger");
		}
//in base alla stanza vado a definire quali sono le piattaforme verso il quale si vuole arrivare
		switch (room.name){
			case "7_Dialog":
				target_teleport1 = GameObject.Find("6_Map").transform.FindChild("teleport1");
				target_teleport2 = GameObject.Find("3_Life").transform.FindChild("teleport2");
				break;
			case "6_Map":
				if (first){
					first = false;
					active = true;
				}
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
//vado a vedere se il portale e attivo e nel caso lo fosse vado a spostare il player sopra la piattaforma di arrivo
			
			
			if (active){
				
				switch (room.name){
				case "7_Dialog":
					if (this.name == "teleport3_trigger"){
						map.FindChild("7_platform").FindChild("MovementTrigger").GetComponent<HUDPosition>().active = true;
					}
					break;
				case "3_Life":
					if (this.name == "teleport1_trigger"){
						map.FindChild("3_platform").FindChild("MovementTrigger").GetComponent<HUDPosition>().active = true;
					}
					break;
				}
				
				if (room.name == "7_Dialog"){
					if (this.name == "teleport1_trigger" || this.name == "teleport3_trigger"){
						player.transform.position = target_teleport2.position;
						
					}else{
						player.transform.position = target_teleport1.position;
					}			
				}
				else if (this.name == "teleport2_trigger"){
					player.transform.position = target_teleport1.position;
				}else{
					player.transform.position = target_teleport2.position;
				}
			}
		}
	}
	
	
	void OnTriggerExit (Collider other) {	
		if (other.tag == "Player"){
//vado a vedere se il portale è attivo (ovvero lo sto abbandonando) e nel caso lo fosse disattivo i portali 
//altrimenti (ovvero ho appena raggiunto il portale) li riattivo
			if (active){
				if (room.name == "7_Dialog"){
					if (this.name == "teleport3_trigger"){
						my_teleport1.GetComponent<Teleport>().active = false;
						my_teleport2.GetComponent<Teleport>().active = false;
					}
				}
				active = false;
			}else{
				if (room.name == "4_Menu"){
					my_teleport1.GetComponent<Teleport>().active = true;
				}else if (room.name == "1_Esc"){
					my_teleport2.GetComponent<Teleport>().active = true;
				}else if (room.name == "7_Dialog"){
					if (this.name == "teleport2_trigger" && my_teleport1.GetComponent<Teleport>().active == false){
						my_teleport2.GetComponent<Teleport>().active = true;
						my_teleport3.GetComponent<Teleport>().active = true;
					}else if (this.name == "teleport1_trigger" && my_teleport2.GetComponent<Teleport>().active == false){
						my_teleport1.GetComponent<Teleport>().active = true;
						my_teleport4.GetComponent<Teleport>().active = true;
					}
				}else{
					my_teleport1.GetComponent<Teleport>().active = true;
					my_teleport2.GetComponent<Teleport>().active = true;	
				}
			}
		}
	}
}
