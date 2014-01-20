using UnityEngine;
using System.Collections;

public class Hallway_Two : MonoBehaviour
{
    public static float rotation;
    public bool rot = false;
    public static float total_rot = 0;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rot)
        {
            rotation = 0;
    
            if (Input.GetAxis("Mouse ScrollWheel") > 0 || Character.turn == 1) { rotation = 4f; total_rot += 4f; }
            else  if (Input.GetAxis("Mouse ScrollWheel") < 0 || Character.turn == -1) { rotation = -4f; total_rot -= 4f; }
            transform.Rotate(0, 0, rotation);
        }



        if (total_rot == 180 || total_rot==-180) rot = false;
    }
}
