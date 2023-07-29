
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer12;
    float timer1;
    private void Start()
    {
        timer1 = PlayerPrefs.GetFloat("time", 0);
        updatetimer(timer1);

    }

    void play_game()
    {
        SceneManager.LoadScene("Game");

    }

    void quit_game()
    {
        Debug.Log("Quit");
        Application.Quit();

    }

    void updatetimer(float currenttimer)
    {
        currenttimer += 1;

        float minutes = Mathf.FloorToInt(currenttimer / 60);
        float seconds = Mathf.FloorToInt(currenttimer % 60);

        timer12.text = string.Format("Your Time: " + "{0:00}:{1:00}", minutes, seconds);
    }


}
