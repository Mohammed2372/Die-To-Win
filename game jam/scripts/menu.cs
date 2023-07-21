using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer12;
    float timer1;
   
    void Start()
    {
        timer1 = PlayerPrefs.GetFloat("time", 0);
        updatetimer(timer1);
       
    }
    public void play_game()
    {
        SceneManager.LoadScene("Game");

    }

    public void quit_game()
    {
        Debug.Log("Quit");
        Application.Quit();

    }

    void updatetimer(float currenttimer)
    {
        currenttimer += 1;

        float minutes = Mathf.FloorToInt(currenttimer / 60);
        float seconds = Mathf.FloorToInt(currenttimer % 60);

        timer12.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }

}
