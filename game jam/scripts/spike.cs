using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public float destroyinterval = 2f;
    private float timer1 = 0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer1)
        {
            //gameObject.SetActive(false);
            timer1 += destroyinterval;
            
            //EditorUtility.UnloadUnusedAssetsImmediate();
        }
    }
}
