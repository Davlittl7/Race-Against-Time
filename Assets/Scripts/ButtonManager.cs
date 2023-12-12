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
        SceneManager.LoadScene("Cutscene1Pre");
    }
    public void toContinueGame()
    {
        if (!PlayerPrefs.HasKey("currLevel")) SceneManager.LoadScene("Cutscene1Pre");
        else SceneManager.LoadScene(PlayerPrefs.GetInt("currLevel"));
    }

    public void toHowTo()
    {
        SceneManager.LoadScene(1);
    }

    public void toCredits()
    {
        SceneManager.LoadScene(2);
    }
}
