using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalplatforms : MonoBehaviour
{
    private PlatformEffector2D effector;
    float waittime;
    float temptime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    // Update is called once per frame
    void Update()
    {

        //changing the effecotor rotational offset to its original without space
        temptime += Time.deltaTime;
        if(temptime > 0.15f)
        {
            effector.rotationalOffset = 0;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            waittime = 0.1f; // the time player should press the key to go down 
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            temptime = 0; ////
            if(waittime <= 0)
            {
                effector.rotationalOffset = 180f;
                waittime = 0.1f;
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
}
