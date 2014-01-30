using UnityEngine;
using System.Collections;

public class DoorProt : MonoBehaviour {

    protected Animator animator;
    public bool closed, opened;

    void Start () {
        animator = transform.parent.GetChild(0).gameObject.GetComponent<Animator>();
      
	}
    void Update()
    {
     /*   if(Input.GetKeyUp(KeyCode.P))
        {
            animator.SetBool("Open", !animator.GetBool("Open"));
        }
      * */
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "First Person Controller" && !closed)
        {
            animator.SetBool("Open", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "First Person Controller" && !opened)
        {
            animator.SetBool("Open", false);
        }
    }
}
