using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public GameObject door_left, door_right, level, square_one, square_two,
                                door_circle;
    protected GameObject wall_back_one, wall_back_two,
								wall_front_one, wall_front_two, wall_left_one,
								wall_left_two, wall_right_one, wall_right_two,parent, ottagono_uno, ottagono_due,
                                close_door, open_door;
    GameObject gui, controller, anti;
    bool idiot, diff,jump, jump_avaiable,floor,active_doors;
    protected int i = 0, j=0, jump_count =0, door_number = 0;
	// Use this for initialization
	void Start () {
        gui = GameObject.Find("GUI Text");
        controller = GameObject.Find("First Person Controller");
        level = GameObject.Find("Level");
        
		square_one = GameObject.Find("Square_One");
        square_two = GameObject.Find("Square_Two");
	// IO	
		wall_back_one = GameObject.Find("Wall_Back_1");
		wall_back_two = GameObject.Find("Wall_Back_2");
        
		wall_front_one = GameObject.Find("Wall_Front_1");
		wall_front_two = GameObject.Find("Wall_Front_2");
		
		wall_left_one = GameObject.Find("Wall_Left_1");
		wall_left_two = GameObject.Find("Wall_Left_2");
		
		wall_right_one = GameObject.Find("Wall_Right_1");
		wall_right_two = GameObject.Find("Wall_Right_2");

        close_door = GameObject.Find("Close_door");
        open_door = GameObject.Find("Open_door");



        ottagono_uno = GameObject.Find("Octagon_1");
        ottagono_due = GameObject.Find("Octagon_2");

        // Blocca movimento mouse
         controller.GetComponent<MouseLook>().camera_active = false;
        // Blocca movimento
         controller.GetComponent<CharacterMotor>().canControl = false;
         controller.GetComponent<CharacterMotor>().jumping.enabled = false;
		
	//IO	
		anti = GameObject.Find("Anti");
        idiot = false;
        diff = true;
	}
	
	// Update is called once per frame
	void Update () {
        


        if (idiot && Input.GetKey(KeyCode.Space) && controller.GetComponent<CharacterMotor>().canControl == true) { gui.GetComponent<GuiText>().TypeOut(0, 18,18); idiot = false; }
        if (jump_avaiable){
            
            
           if (Input.GetKeyUp(KeyCode.Space)) jump_count++;
           if (jump_count > 7) { gui.GetComponent<GuiText>().TypeOut(0, 29, 29); jump_count = 0; }
              if (Input.GetAxis("Mouse ScrollWheel") != 0) { gui.GetComponent<GuiText>().TypeOut(0, 30, 30); jump_avaiable = false; }
        }
        if (Input.GetKeyDown(KeyCode.Space)) jump = true;
    
    }
	
	void setWall(GameObject muro, bool b){
		//muro.SetActive(b);

        muro.renderer.enabled = b;
      
        muro.transform.GetChild(0).renderer.enabled = b;
        muro.transform.GetChild(0).GetComponent<BoxCollider>().enabled = b;
	}

	
	void ResetRoom1(){
		setWall(wall_back_one, true);
		setWall(wall_front_one, true);
		setWall(wall_left_one, true);
		setWall(wall_right_one, true);
        

	}
	
	void ResetRoom2(){
		setWall(wall_back_two, true);
		setWall(wall_front_two, true);
		setWall(wall_left_two, true);
		setWall(wall_right_two, true);
       
	
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
			controller.GetComponent<FPSInputController>().Disorient = true;
            gui.GetComponent<GuiText>().TypeOut(0, 6, 6);
           
            other.enabled = false;
          
        }

        else if (other.gameObject.name == "Disoriented_2")
        {
            controller.GetComponent<FPSInputController>().Disorient = false;
            controller.GetComponent<FPSInputController>().Disorient_2 = true;
            gui.GetComponent<GuiText>().TypeOut(0, 7, 8);
            other.enabled = false;
            

        }
		
		
        else	if(other.gameObject.name == "Oriented")
		{
            controller.GetComponent<FPSInputController>().Disorient_2 = false;
            controller.GetComponent<CharacterMotor>().canControl = false;
            controller.GetComponent<MouseLook>().camera_active = true;
            gui.GetComponent<GuiText>().TypeOut(0, 9, 11);
            
            other.enabled = false;
          
           
		}
		
		else if(other.gameObject.name == "Door_trigger_close")
		{
			door_left.GetComponent<Door>().close = true;
			door_right.GetComponent<Door>().close = true;
			
		}
        else  if (other.gameObject.name == "Rotation")
        {
           GameObject.Find("Hallway_Two").GetComponent<Hallway_Two>().rot = true;
           jump_avaiable = true;
           gui.GetComponent<GuiText>().TypeOut(0, 28, 28);
           other.enabled = false;
          
      
        }
        else   if (other.gameObject.name == "Idiot")
        {
            idiot = false;
            other.enabled = false;
            

        }

        else if (other.gameObject.tag == "wall")
        {
            int i = Random.Range(19, 24);
            gui.GetComponent<GuiText>().TypeOut(0, i,i);


        }

        else if (other.gameObject.name == "Wall_5")
        {
           
            gui.GetComponent<GuiText>().TypeOut(0, 24,24);
            other.enabled = false;

        }


        else if (other.gameObject.name == "Wall_6")
        {

            gui.GetComponent<GuiText>().TypeOut(0, 25, 25);
            

        }



        else if (other.gameObject.name == "Hallway_Two_Start")
        {
            other.enabled = false;
          
            controller.GetComponent<CharacterMotor>().canControl = false;
            gui.GetComponent<GuiText>().TypeOut(0, 26,27);


        }

        else if (other.gameObject.name == "Exit_Two")
        {

            jump_avaiable = false;
            jump_count = 0;
            gui.GetComponent<GuiText>().TypeOut(0, 31,31);
            controller.GetComponent<CharacterMotor>().canControl = false;
            Destroy(GameObject.Find("Anti-Roof"));
            other.enabled = false;

        }
        else if (other.gameObject.name == "Diff_Easy" && diff)
        {
            anti.transform.position = new Vector3(7, anti.transform.position.y, anti.transform.position.z);
            gui.GetComponent<GuiText>().TypeOut(0, 1, 1);
            GameObject.Find("Medium_Door").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("Hard_Door").GetComponent<BoxCollider>().enabled = false;
            other.enabled = false;
            diff = false;
           

        }
        else if (other.gameObject.name == "Diff_Medium" && diff)
        {
            anti.transform.position = new Vector3(0, anti.transform.position.y, anti.transform.position.z);
            gui.GetComponent<GuiText>().TypeOut(0, 2, 2);
            GameObject.Find("Easy_Door").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("Hard_Door").GetComponent<BoxCollider>().enabled = false;
            other.enabled = false;
            diff = false;
           
        }
        else if (other.gameObject.name == "Diff_Hard" && diff)
        {
            anti.transform.position = new Vector3(-7, anti.transform.position.y, anti.transform.position.z);
            gui.GetComponent<GuiText>().TypeOut(0, 3, 3);
            GameObject.Find("Medium_Door").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("Easy_Door").GetComponent<BoxCollider>().enabled = false;
            other.enabled = false;
            diff = false;
            

        }


        if (other.gameObject.name == "Tutorial_1")
        {

            controller.GetComponent<CharacterMotor>().canControl = false;
            gui.GetComponent<GuiText>().TypeOut(0, 4,5);


        }

        else if (other.gameObject.name == "S_Trigger" )
        {
            
          controller.GetComponent<MouseLook>().camera_rot = 45;
          gui.GetComponent<GuiText>().TypeOut(0, 12,12);
          other.enabled = false;
           


        }

        else if (other.gameObject.name == "A_Trigger" )
        {

          controller.GetComponent<MouseLook>().camera_rot = 110;
          gui.GetComponent<GuiText>().TypeOut(0, 13,13);
          other.enabled = false;
           


        }

        else if (other.gameObject.name == "W_Trigger")
        {

            controller.GetComponent<MouseLook>().camera_rot = 220;
            gui.GetComponent<GuiText>().TypeOut(0, 14,14);
            other.enabled = false;
            


        }
        else if (other.gameObject.name == "Normal_Trigger")
        {

            controller.GetComponent<MouseLook>().camera_rot = 0;
            gui.GetComponent<GuiText>().TypeOut(0, 15,16);
            other.enabled = false;
   



        }

        else if (other.gameObject.name == "Platform_Start")
        {

            controller.GetComponent<CharacterMotor>().jumping.enabled = true;
            gui.GetComponent<GuiText>().TypeOut(0, 17,17);
            idiot = true;
            other.enabled = false;
            controller.GetComponent<CharacterMotor>().canControl = false;




        }


       if (other.gameObject.tag == "door")
        {
            
          
            if (active_doors)
            {  door_number++;
           
               
                if (door_number < 10)
                {
                    Debug.Log("aiu");
                    int i = Random.Range(32, 35);
                    gui.GetComponent<GuiText>().TypeOut(0, i, i);
                }
                else gui.GetComponent<GuiText>().TypeOut(0, 35, 35);
            }

            active_doors = false;
        }
      
    

        if (other.gameObject.name == "Center_1")
        {
	 	   //  other.gameObject.GetComponent<BoxCollider>().active = false;
          

	     	 level.transform.position = level.transform.position + square_one.transform.position - anti.transform.position + new Vector3(0, -6, -0.5f) ;
             active_doors = true;
			
			
		}
        else if (other.gameObject.name == "Center_2")
        {
            //other.gameObject.GetComponent<BoxCollider>().active = false;

            active_doors = true;
            level.transform.position = level.transform.position + square_two.transform.position - anti.transform.position + new Vector3(0, -6, -0.5f);
			
        }

        

        else if (other.gameObject.name == "Door_Front_1")
        {
           //other.gameObject.GetComponent<BoxCollider>().active = false;

            
            square_two.transform.position = square_one.transform.position + new Vector3(0, 0, 31);
            reser_due();
			
//			wall_back_two.SetActiveRecursively(false);
			
			ResetRoom1();
            ResetRoom2();
            setWall(wall_back_two, false);
        }
        else if (other.gameObject.name == "Door_Front_2")
        {
           // other.gameObject.GetComponent<BoxCollider>().active = false;


            square_one.transform.position = square_two.transform.position + new Vector3(0, 0, 31);
            reser_uno();
//			wall_back_one.SetActiveRecursively(false);

            ResetRoom1();
            ResetRoom2();
            setWall(wall_back_one, false);
        }
        else if (other.gameObject.name == "Door_Back_1")
        {
           // other.gameObject.GetComponent<BoxCollider>().active = false;


            square_two.transform.position = square_one.transform.position + new Vector3(0, 0, -31);
            reser_due();

//			wall_front_two.SetActiveRecursively(false);

            ResetRoom1();
            ResetRoom2();
            setWall(wall_front_two, false);
        }
        else if (other.gameObject.name == "Door_Back_2")
        {
           // other.gameObject.GetComponent<BoxCollider>().active = false;


            square_one.transform.position = square_two.transform.position + new Vector3(0, 0, -31);
            reser_uno();

//			wall_front_one.SetActiveRecursively(false);

            ResetRoom1();
            ResetRoom2();
            setWall(wall_front_one, false);
        }
        else if (other.gameObject.name == "Door_Right_1")
        {
           // other.gameObject.GetComponent<BoxCollider>().active = false;


            square_two.transform.position = square_one.transform.position + new Vector3(31, 0, 0);
            reser_due();

//			wall_left_two.SetActiveRecursively(false);

            ResetRoom1();
            ResetRoom2();
            setWall(wall_left_two, false);
        }
        else if (other.gameObject.name == "Door_Right_2")
        {
          //  other.gameObject.GetComponent<BoxCollider>().active = false;


            square_one.transform.position = square_two.transform.position + new Vector3(31, 0, 0);
            reser_uno();

			//wall_left_one.SetActiveRecursively(false);

            ResetRoom1();
            ResetRoom2();
            setWall(wall_left_one, false);
        }
        else if (other.gameObject.name == "Door_Left_1")
        {
          //  other.gameObject.GetComponent<BoxCollider>().active = false;


            square_two.transform.position = square_one.transform.position + new Vector3(-31, 0, 0);
            reser_due();

			//wall_right_two.SetActiveRecursively(false);

            ResetRoom1();
            ResetRoom2();
            setWall(wall_right_two, false);
        }
        else if (other.gameObject.name == "Door_Left_2")
        {
         //   other.gameObject.GetComponent<BoxCollider>().active = false;


            square_one.transform.position = square_two.transform.position + new Vector3(-31, 0, 0);
            reser_uno();

//			wall_right_one.SetActiveRecursively(false);

            ResetRoom1();
            ResetRoom2();
            setWall(wall_right_one, false);
        }


            // Close the Door_start
        else	if(other.gameObject.name == "Close_door")
        {
            close_door.GetComponent<BoxCollider>().isTrigger = false;
        }
        else if (other.gameObject.name == "Open_door")
        {
            close_door.GetComponent<BoxCollider>().isTrigger = true;
        }


        if (other.gameObject.name == "Exit_Door_1")
        {
            gui.GetComponent<GuiText>().TypeOut(0, 38, 40);
            other.enabled = false;

        }
        else if (other.gameObject.name == "Exit_Door_2")
        {
            Application.LoadLevel("InitialMenu");


        }

     

     
     
     
        }
    void OnTriggerStay(Collider other)
    {


        if (other.gameObject.name == "Octagon_One" )
        {
            if (i <= 8 && !controller.GetComponent<CharacterMotor>().grounded && controller.GetComponent<CharacterMotor>().movement.velocity.y < 0 && jump)
            {
               
                jump = false;
                i++;
                if (!floor) { gui.GetComponent<GuiText>().TypeOut(0, 36, 37); floor = true; }
           ottagono_uno.transform.position = new Vector3(ottagono_uno.transform.position.x, ottagono_uno.transform.position.y - 1f, ottagono_uno.transform.position.z);
           active_doors = false;
            }
        }
        if (other.gameObject.name == "Octagon_Two")
        {
            if (j <= 8 && !controller.GetComponent<CharacterMotor>().grounded && controller.GetComponent<CharacterMotor>().movement.velocity.y < 0 && jump)
            {
            
                jump = false;
                j++;
                if (!floor) { gui.GetComponent<GuiText>().TypeOut(0, 36, 37); floor = true; }
                ottagono_due.transform.position = new Vector3(ottagono_due.transform.position.x, ottagono_due.transform.position.y - 1f, ottagono_due.transform.position.z);
                active_doors = false;
            }
        }
    }

    protected void reser_uno()
    {
        ottagono_uno.transform.position = new Vector3(ottagono_uno.transform.position.x, -4.5f, ottagono_uno.transform.position.z);
        i = 0;

    }
    protected void reser_due()
    {
        ottagono_due.transform.position = new Vector3(ottagono_due.transform.position.x, -4.5f, ottagono_due.transform.position.z);
       j = 0;
    }

  
      }