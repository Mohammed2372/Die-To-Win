using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float timerleft;
    public bool timeron = false;

    public TextMeshProUGUI timertext;
    private void Start()
    {
        timeron = true;
    }

    private void Update()
    {
        if (timeron)
        {
            if(timerleft > 0) 
            { 
            timerleft -= Time.deltaTime;
                updatetimer(timerleft);
            }
            else
            {
                timerleft = 0;
                timeron = false;
            }
        }
    }
    void updatetimer(float currenttimer)
    {
        currenttimer += 1;

        float minutes = Mathf.FloorToInt(currenttimer/60);
        float seconds = Mathf.FloorToInt(currenttimer % 60);

        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
