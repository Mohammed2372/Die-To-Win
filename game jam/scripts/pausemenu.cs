using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject optionpanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }

    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        optionpanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        optionpanel.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("loading menu....");
        SceneManager.LoadScene("main");
    }
    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }
    public void Option()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        optionpanel.SetActive(true);
    }
    
}

