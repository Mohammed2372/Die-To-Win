using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalplatforms : MonoBehaviour
{
    private PlatformEffector2D effector;
    float waittime;
    float temptime;

    bool down = false;
    public Joystick joystick;
    [HideInInspector] public float vertical_move = 0;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // vertical move in joystick
        vertical_move = joystick.Vertical;

        //changing the effecotor rotational offset to its original without space
        temptime += Time.deltaTime;
        if(temptime > 0.2f)
        {
            effector.rotationalOffset = 0;
        }

        //if (/*Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S) ||*/ vertical_move <= -.7f)
        //{
        //    waittime = 0.1f; // the time player should press the key to go down 
        //}

        if (/*Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ||*/ vertical_move <= -.5f) //uncomment those two lines in windows version
        {
            temptime = 0; ////
            effector.rotationalOffset = 180f;
            waittime = 0.1f;
                
            if(waittime <= 0) // in windows version, get those two above line back in the if state again
            {
            }
            else
            {
                waittime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }
    }
    public void movedown(bool boo)
    {
        down = boo;
    }
}
