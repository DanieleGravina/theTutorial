using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public GameObject door_left, door_right, level, square_one, square_two ;
    protected GameObject wall_back_one, wall_back_two,
                                wall_front_one, wall_front_two, wall_left_one,
                                wall_left_two, wall_right_one, wall_right_two, parent, ottagono_uno, ottagono_due,
                                fallway, hallway, hallway_two, labirint, shortway, lux_W, lux_A, lux_S, lux_D, door_Hallway, light_Long;
    GameObject gui, controller, anti;
    public static int turn = 0;
    bool idiot, diff,jump, jump_avaiable,floor,active_doors,move_back,w,a,rot_go,disable_fall_door, flying;
    protected int i = 0, j=0, jump_count =0, door_number = 0;
    public GameObject jumpSound;
    public GameObject footSound;
    protected bool cammina = false;

    void Awake()
    {
        InvokeRepeating("footSoundPlayer", 1.0f, 0.4f);
    }

    void footSoundPlayer()
    {
        if (cammina)
        {
            footSound.audio.Play();
        }
    }

	// Use this for initialization
	void Start () {

		Screen.showCursor = false;
     
		SetVisible(false);
        gui = GameObject.Find("GUI Text");
        controller = GameObject.Find("First Person Controller");
        level = GameObject.Find("Level");
        
		square_one = GameObject.Find("Square_One");
        square_two = GameObject.Find("Square_Two");
        fallway = GameObject.Find("Fallway");
        hallway = GameObject.Find("Hallway");
        hallway_two = GameObject.Find("Hallway_Two");
        labirint = GameObject.Find("Labirint");
        shortway = GameObject.Find("Shortway");
        lux_W = GameObject.Find("Lux_W");
        lux_A = GameObject.Find("Lux_A");
        lux_S = GameObject.Find("Lux_S");
        lux_D = GameObject.Find("Lux_D");
        door_Hallway = GameObject.Find("Trigger_Door_Hallway");
        light_Long = GameObject.Find("Light_Long");

	// IO	
		wall_back_one = GameObject.Find("Wall_Back_1");
		wall_back_two = GameObject.Find("Wall_Back_2");
        
		wall_front_one = GameObject.Find("Wall_Front_1");
		wall_front_two = GameObject.Find("Wall_Front_2");
		
		wall_left_one = GameObject.Find("Wall_Left_1");
		wall_left_two = GameObject.Find("Wall_Left_2");
		
		wall_right_one = GameObject.Find("Wall_Right_1");
		wall_right_two = GameObject.Find("Wall_Right_2");

       
      



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

        fallway.SetActive(false);
        hallway.SetActive(false);
        hallway_two.SetActive(false);
        labirint.SetActive(false);
        shortway.SetActive(false);
        square_one.SetActive(false);
        square_two.SetActive(false);
        lux_D.SetActive(false);
        lux_S.SetActive(false);
        lux_A.SetActive(false);
        lux_W.SetActive(false);
	}

    protected void Atterraggio()
    {
        if (flying && controller.GetComponent<CharacterMotor>().grounded)
        {
            jumpSound.audio.Play();
            flying = false;
        }
    }

	// Update is called once per frame
	void Update () {

        if (!controller.GetComponent<CharacterMotor>().grounded)
        {
            flying = true;
        }

        Atterraggio();
        
        if (controller.GetComponent<CharacterMotor>().grounded && controller.GetComponent<CharacterMotor>().movement.velocity.magnitude != 0)
        {
            cammina = true;
        }
        else
        {
            cammina = false;
        }

        if (idiot && Input.GetKey(KeyCode.Space) && controller.GetComponent<CharacterMotor>().canControl == true) { gui.GetComponent<GuiText>().TypeOut(0, 18,18); idiot = false; }
        if (jump_avaiable){
            
            
           if (Input.GetKeyUp(KeyCode.Space)) jump_count++;
           if (jump_count > 7) { gui.GetComponent<GuiText>().TypeOut(0, 29, 29); jump_count = 0; }
              if (Input.GetAxis("Mouse ScrollWheel") != 0) { gui.GetComponent<GuiText>().TypeOut(0, 30, 30); jump_avaiable = false; }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            if (jump_avaiable)
            {
                flying = true;
            }
        }

        if (rot_go) controller.GetComponent<MouseLook>().camera_rot += Time.deltaTime * 7;
    
    }

    void setWall(GameObject muro, bool b)
    {


        muro.SetActive(b);
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
		
        switch(other.gameObject.name){
            case "Idiot2":
                GameObject.Find("Trigger_Fall").GetComponent<DoorProt>().closed = true;
                other.enabled=false;
                break;
            case "D_Trigger_Attivate":
                lux_D.SetActive(true);
                break;
            case "Door_Trigger" : 
                door_left.GetComponent<Door>().open = true;
			    door_right.GetComponent<Door>().open = true;
                break;

            case "Disoriented" :
                controller.GetComponent<FPSInputController>().Disorient = true;
                gui.GetComponent<GuiText>().TypeOut(0, 6, 6);

                GameObject.Find("Cube_No").SetActive(false);
                other.enabled = false;
                break;
                
            case "Disoriented_2" :
                controller.GetComponent<FPSInputController>().Disorient = false;
                controller.GetComponent<FPSInputController>().Disorient_2 = true;
                gui.GetComponent<GuiText>().TypeOut(0, 7, 8);
                other.enabled = false;
                labirint.SetActive(true);
                break;

            case "Oriented":
                controller.GetComponent<FPSInputController>().Disorient_2 = false;
                controller.GetComponent<CharacterMotor>().canControl = false;
                controller.GetComponent<MouseLook>().camera_active = true;
                gui.GetComponent<GuiText>().TypeOut(0, 9, 11);
                anti.transform.parent = level.transform;
                Destroy(GameObject.Find("Anti-Roof"));
                anti.SetActive(false);


                //LIGHT
                light_Long.SetActive(false);
                lux_S.SetActive(true);
                
                door_Hallway.GetComponent<DoorProt>().closed = true;

                other.enabled = false;
                break;

            case "S_Trigger_Att":
                lux_D.SetActive(false);
                lux_A.SetActive(true);
                break;
            case "S_Trigger_Dis":
                lux_D.SetActive(true);
                lux_A.SetActive(false);
                break;

            case "A_Trigger_Att":
                lux_S.SetActive(false);
                lux_W.SetActive(true);
                break;
            case "A_Trigger_Dis":
                lux_S.SetActive(true);
                lux_W.SetActive(false);
                break;

            case "W_Trigger_Att":
                lux_A.SetActive(false);
                break;
            case "W_Trigger_Dis":
                lux_A.SetActive(true);
                break;

            case "Door_trigger_close" :
    			door_left.GetComponent<Door>().close = true;
	    		door_right.GetComponent<Door>().close = true;
                break;

            case  "Rotation" :
               GameObject.Find("Hallway_Two").GetComponent<Hallway_Two>().rot = true;
               jump_avaiable = true;
               gui.GetComponent<GuiText>().TypeOut(0, 28, 28);
               other.enabled = false;
                break;

            case "Idiot" :
                idiot = false;
                other.enabled = false;
                break;


            case "I_P" :
                gui.GetComponent<GuiText>().TypeOut(0, 24,24);
                other.enabled = false;
                other.gameObject.transform.GetChild(0).renderer.enabled = true;
                break;

            case "W_6" :
                gui.GetComponent<GuiText>().TypeOut(0, 25, 25);
                other.gameObject.transform.GetChild(0).renderer.enabled = true;
                break;

            case "Hallway_Two_Start":
                other.enabled = false;
                GameObject.Find("Trigger_Exit_Fall").GetComponent<DoorProt>().closed = true;
                controller.GetComponent<CharacterMotor>().canControl = false;
                gui.GetComponent<GuiText>().TypeOut(0, 26,27);
                break;

            case "Trigger_Exit_Fall":
                hallway_two.SetActive(true);
                square_one.SetActive(true);
                square_one.transform.parent = null;

                break;

            case "Exit_Two":

                if (Hallway_Two.total_rot < 180 || Hallway_Two.total_rot > -180)
                {
                    if (Hallway_Two.total_rot >= 0)
                   turn = 1; else turn = -1;

                  
                }
                anti.transform.parent = level.transform;
           
                  square_two.SetActive(true);
                square_two.transform.parent = null;
                jump_avaiable = false;
                jump_count = 0;
                gui.GetComponent<GuiText>().TypeOut(0, 31,31);
                controller.GetComponent<CharacterMotor>().canControl = false;
              
                other.enabled = false;
                break;
                
            case  "Trigger_easy":

                if (diff)
                {
                    level.transform.position = new Vector3(-7, level.transform.position.y, level.transform.position.z);

                    gui.GetComponent<GuiText>().TypeOut(0, 1, 1);
                    GameObject.Find("Trigger_medium").collider.enabled = false;
                    GameObject.Find("Trigger_hard").collider.enabled = false;
                    GameObject.Find("Trigger_medium").GetComponent<DoorProt>().closed = true;
                    GameObject.Find("Trigger_hard").GetComponent<DoorProt>().closed = true;
                    hallway.SetActive(true);


                    diff = false;
                }
           break;
        
            case "Trigger_medium":
            if(diff){
            level.transform.position = new Vector3(0, level.transform.position.y, level.transform.position.z);
            gui.GetComponent<GuiText>().TypeOut(0, 2, 2);
            GameObject.Find("Trigger_easy").collider.enabled = false;
            GameObject.Find("Trigger_hard").collider.enabled = false;
            GameObject.Find("Trigger_easy").GetComponent<DoorProt>().closed = true;
            GameObject.Find("Trigger_hard").GetComponent<DoorProt>().closed = true;
            diff = false;
            hallway.SetActive(true);
            }
                break;
            

            case "Trigger_hard":
            if(diff){
            level.transform.position = new Vector3(7, level.transform.position.y, level.transform.position.z);
            GameObject.Find("Trigger_medium").collider.enabled = false;
            GameObject.Find("Trigger_easy").collider.enabled = false;
            gui.GetComponent<GuiText>().TypeOut(0, 3, 3);
            GameObject.Find("Trigger_medium").GetComponent<DoorProt>().closed = true;
            GameObject.Find("Trigger_easy").GetComponent<DoorProt>().closed = true;
        
            diff = false;
            hallway.SetActive(true);
            }
                break;

            case "Tutorial_1":
                GuiText.early_win = false;
            controller.GetComponent<CharacterMotor>().canControl = false;
            gui.GetComponent<GuiText>().TypeOut(0, 4,5);
            other.enabled = false;
                     GameObject.Find("Trigger_easy").GetComponent<DoorProt>().closed = true;
                GameObject.Find("Trigger_medium").GetComponent<DoorProt>().closed = true;
                GameObject.Find("Trigger_hard").GetComponent<DoorProt>().closed = true;
                
              
               
                break;
        
            case "S_Trigger" :

                rot_go = true;
          gui.GetComponent<GuiText>().TypeOut(0, 12,12);
          other.enabled = false;
                break;

            case "A_Trigger" :
         
          if (!a) gui.GetComponent<GuiText>().TypeOut(0, 13,13);
          a = true;
          hallway.SetActive(true);
          fallway.SetActive(false);
          shortway.SetActive(false);
                break;

            case "W_Trigger":
          
            if (!w) gui.GetComponent<GuiText>().TypeOut(0, 14,14);
            w = true;
                  hallway.SetActive(false);
          fallway.SetActive(true);
          shortway.SetActive(true);
                break;

            case "Normal_Trigger":
            controller.GetComponent<MouseLook>().camera_rot = 0;
            rot_go = false;
            SetVisible(false);
            gui.GetComponent<GuiText>().TypeOut(0, 15,16);
            other.enabled = false;
                break;

            case "Trigger_Fall":
                if (!disable_fall_door)
                {
                  
                
                    controller.GetComponent<CharacterMotor>().jumping.enabled = true;
                    gui.GetComponent<GuiText>().TypeOut(0, 17, 17);
                    idiot = true;
                    controller.GetComponent<CharacterMotor>().canControl = false;
                    disable_fall_door = true;
                }
                break;

            case "door":
            if (active_doors)
                {  
                door_number++;
                    if (door_number < 10)
                    {
                        Debug.Log("aiu");
                        int f = Random.Range(32, 35);
                        gui.GetComponent<GuiText>().TypeOut(0, f, f);
                    }
                    else 
                        gui.GetComponent<GuiText>().TypeOut(0, 35, 35);
                    

                active_doors = false;
            }
            break;


            case "Center_1":
                   if(fallway.activeSelf) fallway.SetActive(false);
             if (hallway_two.activeSelf) hallway_two.SetActive(false);
             if (!anti.activeSelf) anti.SetActive(true);
            
	     	 level.transform.position = level.transform.position + square_one.transform.position - anti.transform.position + new Vector3(0, -6, -0.5f) ;
             active_doors = true;
          
                break;

            case "Center_2":
                   if(fallway.activeSelf) fallway.SetActive(false);
             if (hallway_two.activeSelf) hallway_two.SetActive(false);
             if (!anti.activeSelf) anti.SetActive(true);
            
            active_doors = true;
            level.transform.position = level.transform.position + square_two.transform.position - anti.transform.position + new Vector3(0, -6, -0.5f);
             
                break;

            case "Trigger_Door_Front_1":
            square_two.transform.position = square_one.transform.position + new Vector3(0, 0, 31);
            reser_due();
			
			
			ResetRoom1();
            ResetRoom2();
            setWall(wall_back_two, false);
                break;

            case "Trigger_Door_Front_2":
            square_one.transform.position = square_two.transform.position + new Vector3(0, 0, 31);
            reser_uno();

            ResetRoom1();
            ResetRoom2();
            setWall(wall_back_one, false);
                break;

            case  "Trigger_Door_Back_1":

            if (move_back)
            {
                square_two.transform.position = square_one.transform.position + new Vector3(0, 0, -31);
            



                ResetRoom1();
                ResetRoom2();
                setWall(wall_front_two, false);
            }
            else move_back = true;
                break;

            case "Trigger_Door_Back_2":
            square_one.transform.position = square_two.transform.position + new Vector3(0, 0, -31);
           

            ResetRoom1();
            ResetRoom2();
            setWall(wall_front_one, false);
                break;

            case "Trigger_Door_Right_1":
            square_two.transform.position = square_one.transform.position + new Vector3(31, 0, 0);
            

            ResetRoom1();
            ResetRoom2();
            setWall(wall_left_two, false);
                break;

            case "Trigger_Door_Right_2":
            square_one.transform.position = square_two.transform.position + new Vector3(31, 0, 0);
           

            ResetRoom1();
            ResetRoom2();
            setWall(wall_left_one, false);
                break;

            case "Trigger_Door_Left_1":
            square_two.transform.position = square_one.transform.position + new Vector3(-31, 0, 0);
            

            ResetRoom1();
            ResetRoom2();
            setWall(wall_right_two, false);
                break;

            case "Trigger_Door_Left_2":
            square_one.transform.position = square_two.transform.position + new Vector3(-31, 0, 0);
          
            ResetRoom1();
            ResetRoom2();
            setWall(wall_right_one, false);
                break;

            case "Exit_Door_1":
                if (GuiText.early_win) gui.GetComponent<GuiText>().TypeOut(0, 41,43); else
            gui.GetComponent<GuiText>().TypeOut(0, 38, 40);
            controller.GetComponent<CharacterMotor>().canControl = false;
            controller.GetComponent<MouseLook>().camera_active = true;
                   GameObject.Find("Trigger_easy").GetComponent<DoorProt>().closed = true;
                GameObject.Find("Trigger_medium").GetComponent<DoorProt>().closed = true;
                GameObject.Find("Trigger_hard").GetComponent<DoorProt>().closed = true;
                   GameObject.Find("Trigger_medium").collider.enabled = false;
                    GameObject.Find("Trigger_hard").collider.enabled = false;
            
                    GameObject.Find("Trigger_easy").collider.enabled = false;
            other.enabled = false;
                break;

            case "Exit_Door_2":
            Application.LoadLevel("InitialMenu");
            Screen.showCursor = true;
                break;
			
		case "Visible":
			
			SetVisible(true);
			   labirint.SetActive(false);
                shortway.SetActive(false);
			
			break;
					
		case "Invisible":
			SetVisible(false);
			
			
			
			
			break;
}


        if (other.gameObject.tag == "wall")
        {
            int i = Random.Range(19, 24);
            gui.GetComponent<GuiText>().TypeOut(0, i, i);
            other.gameObject.transform.GetChild(0).renderer.enabled = true;
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
          ottagono_uno.transform.position = new Vector3(ottagono_uno.transform.position.x, ottagono_uno.transform.position.y -1, ottagono_uno.transform.position.z);
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
              ottagono_due.transform.position = new Vector3(ottagono_due.transform.position.x, ottagono_due.transform.position.y -1, ottagono_due.transform.position.z);
                active_doors = false;
            }
        }
    }
	void SetVisible(bool b){
			GameObject.Find("Wall_1").GetComponent<MeshRenderer>().enabled = b;
			GameObject.Find("Wall_4").GetComponent<MeshRenderer>().enabled = b;
			GameObject.Find("Wall_6").GetComponent<MeshRenderer>().enabled = b;
            GameObject.Find("Invisible_Platform").GetComponent<MeshRenderer>().enabled = b;
            GameObject.Find("I_P").collider.enabled = true;
			}
			
    void OnTriggerExit(Collider other)
    {


        if (other.gameObject.name == "Octagon_One")
        
            reser_due();

        if (other.gameObject.name == "Octagon_Two") reser_uno();
        }

    protected void reser_uno()
    {
        ottagono_uno.transform.position = new Vector3(ottagono_uno.transform.position.x, -4.25f, ottagono_uno.transform.position.z);
        i = 0;

    }
    protected void reser_due()
    {
        ottagono_due.transform.position = new Vector3(ottagono_due.transform.position.x, -4.25f, ottagono_due.transform.position.z);
       j = 0;
    }
}