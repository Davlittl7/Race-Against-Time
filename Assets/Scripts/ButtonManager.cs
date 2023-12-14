using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void toMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void toStartNewGame()
    {
        PlayerPrefs.SetInt("currLevel", 3);
        SceneManager.LoadScene("Cutscene1Pre");
    }
    public void toContinueGame()
    {
        if (!PlayerPrefs.HasKey("currLevel"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Cutscene1Pre");
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(PlayerPrefs.GetInt("currLevel"));
        }
    }

    public void toHowTo()
    {
        SceneManager.LoadScene(1);
    }

    public void toCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void toQuit()
    {
        Application.Quit();
    }
}
