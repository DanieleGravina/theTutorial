using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public GameObject door_left, door_right;
    GameObject gui, controller, anti;
    bool idiot, diff;
	// Use this for initialization
	// try
	void Start () {
        gui = GameObject.Find("GUI Text");
        controller = GameObject.Find("First Person Controller");
        anti = GameObject.Find("Anti");
        idiot = false;
        diff = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (idiot && Input.GetKey(KeyCode.Space) && controller.GetComponent<CharacterMotor>().canControl == true) { gui.GetComponent<GuiText>().TypeOut(0, 12, 12); idiot = false; }
	}
	
	void OnTriggerEnter(Collider other)


	{
		if(other.gameObject.name == "Door_trigger")
		{
			door_left.GetComponent<Door>().open = true;
			door_right.GetComponent<Door>().open = true;
			
		}
		
        else 	if(other.gameObject.name == "Disoriented")
		{
			GameObject.Find("First Person Controller").GetComponent<FPSInputController>().Disorient = true;
            gui.GetComponent<GuiText>().TypeOut(0, 5, 7);
            other.gameObject.GetComponent<BoxCollider>().active = false;
        }
		
        else	if(other.gameObject.name == "Oriented")
		{
            controller.GetComponent<FPSInputController>().Disorient = false;
            controller.GetComponent<CharacterMotor>().canControl = false;
            controller.GetComponent<MouseLook>().camera_active = true;
            gui.GetComponent<GuiText>().TypeOut(0, 8, 11);
            controller.GetComponent<CharacterMotor>().jumping.enabled = true;
           other.gameObject.GetComponent<BoxCollider>().active = false;
           idiot = true;
           
		}
		
		else if(other.gameObject.name == "Door_trigger_close")
		{
			door_left.GetComponent<Door>().close = true;
			door_right.GetComponent<Door>().close = true;
			
		}
        else  if (other.gameObject.name == "Rotation")
        {
           GameObject.Find("Hallway_Two").GetComponent<Hallway_Two>().rot = true;
           other.gameObject.GetComponent<BoxCollider>().active = false;
            gui.GetComponent<GuiText>().TypeOut(0, 13, 14);
          
      
        }
        else   if (other.gameObject.name == "Idiot")
        {
            idiot = false;
            other.gameObject.GetComponent<BoxCollider>().active = false;
            

        }
        else if (other.gameObject.name == "Exit_Two")
        {
           
            other.gameObject.GetComponent<BoxCollider>().active = false;
            gui.GetComponent<GuiText>().TypeOut(0, 15, 16);

        }
        else if (other.gameObject.name == "Diff_Easy" && diff)
        {
            anti.transform.position = new Vector3(7,0,0);

            other.gameObject.GetComponent<BoxCollider>().active = false;
            diff = false;
           

        }
        else if (other.gameObject.name == "Diff_Medium" && diff)
        {
            anti.transform.position = new Vector3(0,0,0);
          
            other.gameObject.GetComponent<BoxCollider>().active = false;
            diff = false;
           
        }
        else if (other.gameObject.name == "Diff_Hard" && diff)
        {
           anti.transform.position = new Vector3(-7,0,0);
   
            other.gameObject.GetComponent<BoxCollider>().active = false;
            diff = false;
            

        }

        else if (other.gameObject.name == "A_Trigger" )
        {
            
          controller.GetComponent<MouseLook>().camera_rot = 70;
            
            other.gameObject.GetComponent<BoxCollider>().active = false;
           


        }

        else if (other.gameObject.name == "W_Trigger" )
        {

          controller.GetComponent<MouseLook>().camera_rot = 200;
           
            other.gameObject.GetComponent<BoxCollider>().active = false;
           


        }
        else if (other.gameObject.name == "Normal_Trigger")
        {

            controller.GetComponent<MouseLook>().camera_rot = 0;

            other.gameObject.GetComponent<BoxCollider>().active = false;



        }
      
        }

      void OnControllerColliderHit(ControllerColliderHit hit) 
    {

        if (hit.gameObject.name == "Wall_1")
        {
            Debug.Log("ops");
        }
 
    }
      
	}


