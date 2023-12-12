using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvasGO;


    private bool isPaused;
    private PlayerMovement player;

    [Header("First selected Options")]
    [SerializeField] private GameObject mainMenuFirst;

    private void Start()
    {
        mainMenuCanvasGO.SetActive(false);
    }

    private void Update()
    {
        if (!isPaused)
        {
           Pause();
        } else
        {
            Unpause();
        }
    }

    #region Pause/Unpause Functions

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        //player.enabled = false;
        OpenMainMenu();
    }

    public void Unpause()
    {
        isPaused=false;
        Time.timeScale = 1f;
        CloseAllMenus();
    }

    #endregion

    #region Canvas Activations
    private void OpenMainMenu()
    {
        mainMenuCanvasGO.SetActive(true);
    } 

    private void CloseAllMenus()
    {
        mainMenuCanvasGO.SetActive(false);
    }

    #endregion
}
