using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{

    public void play_game()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void quit_game()
    {
        Debug.Log("Quit");
        Application.Quit();

    }

  


}
