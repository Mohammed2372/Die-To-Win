using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public void play_game()
    {
        SceneManager.LoadScene("Game");

    }

    public void quit_game()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
    


}
