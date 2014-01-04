using UnityEngine;
using System.Collections;

public class GuiText : MonoBehaviour
{

  
    public static string[] livello_uno = {
		"Hi there, I'm IA, and I will guide you through this tutorial. Choose the door you prefer." ,                                       //0
		"I see, you are a coward. My first impression about you was right. Ok crybaby, let's start!",             //1
		"Oh, you chose medium...sooo mainstream. You must be a boring person. Ok, let's start!",                         //2
        "Watch out! We got a badass over here! Ok Mr.Courage, let's start!",              //3
		"I will teach you the controls first, because I think you are an idiot. No offense.",                                   //4
        "Press WASD to move. On the keyboard. With your fingers. Yes, those.",                                     //5
        "What the hell are you doing? Are you normal?",                           //6
        "Control your legs! It's easy!",                          //7 
        "You just have two of them, you are not Rocco Siffredi!",                   //8
        "Oh, finally, you were terrible in there, it was like watching a drunken elephant.",                         //9
        "Ok, now I will teach you the camera, move your mouse to look around.",              //10
        "See you at the end of this simple labirint!",            //11
        "What are you doing with your head? Are you ok?",                                             //12
        "Did your father beated you when you were a child?",                         //13
        "Are you on drugs? That would explain a lot. Also, you have some?",                //14
        "Oh! Sorry! It was my fault! I dropped the camera on the floor! ",                                             //15
        "As you can imagine, I'm terribly sorry!",                                   //16
        "Now i'm gonna teach you the jump. Press the Space Bar." ,        //17
         "NOT NOW, YOU IDIOT!",                         //18
        "Got your noooose!",              //19
        "You pissed the karma off, do not complain.",            //20
        "You wish you have a portal gun, eh?",                                             //21
        "You should lose some weight...no offense fatty!",                         //22
        "Error 708: Your face crashed",                //23
        "You cheater! And I've always been so honest with you...",                                             //24
        "Whops, so close!",                                   //25
        "You had fun jumpin around? I bet you did you special boy! Here, take a candy!",         //26                
        "Now let's try an higher jump, reach the that hole." ,       //27    
           "Mmm...too hard? Free your mind, clear your thoughts, bend some spoons and try again!",                         //28
        "If only you could rotate the room...but how?? Open your stupid mind!",              //29
        "Oh, look, an hamster! Please, don't stop, I need electricity!",            //30
        "Now proceed to the final room. Only one exit is the right one, choose carefully.",                                             //31
        "Today I feel gentle, choose again.",                         //32
        "Ops, another room.",                //33
        "Try again, you'll be more lucky.",                                             //34
        "You have been there for ages! Mankind landed on Mars and Half Life 3 went out!",                                   //35
        "Hey! Don't ruin my home!",         //36                
        "Stop it!",        //37    
        "It seems like you lost hours of you life for nothing. Thank god your life is worthless!",                                   //38
        "See you in the next part of this tutorial!",         //39                
        "PS: You Suck."  //40
                                         };                          
    public static string[] livello_due = { "sono il secondo livello", "prova prova prova", "FRASE 3 asdfqasdfasdfasdf", "E FRASE 4", "frase 5 " };
    int start, end, liv;
    protected bool lapse = false;
    bool ok = false;
    GameObject motor;

    // Use this for initialization
    void Start()
    {
        motor = GameObject.Find("First Person Controller");
        
        TypeOut(0, 0, 0);
      

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0) || lapse)
        {
            lapse = false;


            if (ok)
            {
                guiText.text = " ";
                if (start <= end)
                {
                    ok = false;
                   
                    TypeOut(liv, start, end);


                }
                else
                    motor.GetComponent<CharacterMotor>().canControl = true;
            }
          
        }


    }


    IEnumerator PokeText(string t, int a, int b)
    {
        start = a;
        end = b;
        ok = false;
        char c;
        int i;
        for (i = 0; i < t.Length; i++)
        {
            c = t.ToCharArray()[i];

            guiText.text += c;

          yield return new WaitForSeconds(0);
        }
       

        start++;
        ok = true;
        yield return new WaitForSeconds(4);
        lapse = true;
    }

    public void TypeOut(int i, int s, int f)
    {
        guiText.text = "";
        liv = i ;
        switch (liv)
        {
            case 0: StartCoroutine(PokeText(livello_uno[s], s, f)); break;
            case 1: StartCoroutine(PokeText(livello_due[s], s, f)); break;
        }
    }
}