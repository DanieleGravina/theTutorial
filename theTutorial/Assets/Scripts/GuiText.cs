using UnityEngine;
using System.Collections;

public class GuiText : MonoBehaviour
{

    public float delay = 0.07f;
    public static string[] livello_uno = {
		"Welcome to the tutorial! " ,                                       //0
		"First thing, i'm gonna teach you the basic controls:",             //1
		"Press W-A-S-D or the arrow keys to move.",                         //2
        "If you understood try and reach the door at the end",              //3
		"of the hallway. See you there!",                                   //4
        "Come on! That's not so hard!",                                     //5
        "You just have to press W-A-S-D dammit!",                           //6
        "Or maybe it was D-A-W-S...or S-W-A-D...",                          //7 
        "Ah! You finally did it! You are just terrible!",                   //8
        "It was like watching a drunken elephant!",                         //9
        "Now i'm gonna taaalk slooow to make you understand:",              //10
        "You have to jump into that hole! Press the Space Bar!",            //11
        "Not now, you IDIOT!!",                                             //12
        "Wops, maybe i put it a little to high...",                         //13
        "If you just rotate the room...oh wait, you can't!",                //14
        "You damn cheater!!! ",                                             //15
        "But you did it, so let's go on!"                                   //16
                                         };                          
    public static string[] livello_due = { "sono il secondo livello", "prova prova prova", "FRASE 3 asdfqasdfasdfasdf", "E FRASE 4", "frase 5 " };
    int start, end, liv;

    bool ok = false;
    GameObject motor;

    // Use this for initialization
    void Start()
    {
        motor = GameObject.Find("First Person Controller");
      
        TypeOut(0, 0, 4);
      

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
          


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
            else
            {
                delay = 0f;
               
           
        }
        }


    }


    IEnumerator PokeText(string t, int a, int b)
    {
        start = a;
        end = b;
        delay = 0.07f;
        ok = false;
        char c;
        int i;
        for (i = 0; i < t.Length; i++)
        {
            c = t.ToCharArray()[i];

            guiText.text += c;




            yield return new WaitForSeconds(delay);
        }
        delay = 0.07f;

        start++;
        ok = true;
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