using UnityEngine;
using System.Collections;
using System;


public class GuiText : MonoBehaviour
{
    public static string[] livello_uno = {
	
	"Good morning, my dear! Welcome to the tutorial. Feel free to choose the door you prefer." ,                                       //0
	
	"Oh my! You are not so brave, aren't you? Well, let's start anyway!",             //1
		
	"You are quite a boring person, aren't you? I do appreciate that! Now, please, go on.",                         //2
  
        "Oh! What a brave lad we got here! I won't stop you, please go on.",              //3
	
	"Ok son, I will teach you how to move first. Use WASD to move around. ",                                   //4
        "Press WASD to move. On the keyboard. With your fingers. Yes, those.",                                     //5
        "Oh, what's happening? It is something wrong with you, young man?",                           //6
        "You remind me of a drunken elephant I saw in India when I was young.",                          //7 
        "I shot at him. I was quite a hunter when I was a young lord.",                   //8
        "Oh, you did it indeed! I wasn't quite sure because you look so...poor and red-blooded.",                         //9
        "Oh, sorry, don't listen to the opinions of an old man. Now I will teach you the camera. ",              //10
        "Look around with your mouse. I will wait for you at the end of these rooms, drinking some tea",            //11
        "What are you doing with your head? Are you fine?",                                             //12
        "You must have had a difficult childhood...no money, no servants...look at you now!",                         //13
        "Oh, it's five o'clock! Take your time, i'm not going anywhere, my dear.",                //14
        "Oh my! It was my own fault! I dropped the camera on my shining marble floor! ",                                             //15
        "I'm terribly sorry, I owe you my sincerest apologies.",                                   //16
        "Now I will teach you how to jump. Press the space bar." ,        //17
        "Not now, you peasant",                         //18
        "Well, try another time, I bid you a good luck!",              //19
        "Try again my dear, take your time",            //20
        "What happened? You hit something, didn't you?",                                             //21
        "What was that? Let me see better through my monocle...",                         //22
        "Ops, I guess you are not good at jumping! Back in my days I had a slave for that! Oh oh oh",                //23
        "Well I'll be damned! You are quite full of resources, aren't you young man?",                                             //24
        "Oh Dear Lord! You were so close!",                                   //25
        "You did it! I must say, I am impressed, my dear!",         //26                
        "It is time to try something more difficult...try to jump up there, into that hole." ,       //27    
           "Well that seems to be very hard...try harder, if you will.",                         //28
        "If only you could rotate the room...think about it.",              //29
        "Oh my, that's brilliant! Congratulation son! You look exactly like my little hamster Betty ",            //30
        "Well, you reached the last room, my dear, go in there and choose a door!",                                             //31
        "Oh well, choose again",                         //32
        "Mmm...peculiar...another identic room...this is delightfully intriguing",                //33
        "This is incredibly odd, I'm amused",                                             //34
        "Well, since you are still stuck in there, I suppose I'm gonna make some more tea. ",                                   //35
        "Oh Dear! That's utterly unexpected!",         //36                
        "Good thinking son, maybe you are better then a simple peasant",        //37    
        "Oh! That is exactly where you started! Life is curious sometimes, isn't it?",                                   //38
        "Farewell my son, it was a pleasure to meet you. Although...",         //39                
        "...I still have to teach you the user interface...Very well then, see you later!"  //40
                                         };             
    bool onWriting = true;
    GameObject player;

    bool beginWrite = false;

    public float delay = 0.07f;
    float actualDelay;

    string[] buffer;
    int textPos, index = 0;

    float timer;

    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("First Person Controller");
        TypeOut(0, 0, 0);
        actualDelay = delay;

        timer = 0;

        index = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P)) TypeOut(0,1,2);
        if (Input.GetMouseButtonUp(0))
        {

            if (onWriting)
            {
                actualDelay = 0;
            }
            else
                if (buffer != null && textPos < (buffer.Length - 1))
                {
                    guiText.text = "";
                    actualDelay = delay;
                    textPos++;
                    index = 0;
                  
                        onWriting = true;
                        beginWrite = true;
                }  
                else  if (buffer != null && textPos >= (buffer.Length - 1))
                
                    {
                        player.GetComponent<CharacterMotor>().canControl = true;
                        onWriting = false;
                        beginWrite = false;
                        guiText.text = "";
                    }
                  
                

          
        }

        if (beginWrite && guiText != null && buffer != null)
        {
            timer += Time.deltaTime;

            if (timer >= actualDelay)
            {

                guiText.text += buffer[textPos].ToCharArray()[index];
                timer = 0;
                index++;

                if (index == buffer[textPos].Length)
                {
                    beginWrite = false;
                  
                    index = 0;
                    onWriting = false;
                }

                if (textPos == buffer.Length)
                {

                  
                    beginWrite = false;
                    index = 0;
                  
                    onWriting = false;
                }

            }
        }

    }

    public void TypeOut(int temp, int i, int j)
    {

        buffer = new string[j - i + 1];
        Array.Copy(livello_uno, i, buffer, 0, j - i + 1);
        textPos = 0;
        index = 0;
        guiText.text = "";
        onWriting = true;
        actualDelay = delay;
        beginWrite = true;
    }

}