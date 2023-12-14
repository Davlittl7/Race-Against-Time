using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

    private bool isPaused;

    [Header("Scripts to Deactivate on Pause")]
    [SerializeField] private PlayerMovement player;

    [Header("First selected Options")]
    [SerializeField] private GameObject mainMenuFirst;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }


    private void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    #region Pause/Unpause Functions

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        player.enabled = false;
        OpenMainMenu();
    }

    public void Unpause()
    {
        isPaused=false; 
        player.enabled = true;
        Time.timeScale = 1f;
        CloseAllMenus();
    }

    #endregion

    #region Canvas Activations
    private void OpenMainMenu()
    {
        pauseMenu.SetActive(true);
        mainMenuFirst.SetActive(true);
        EventSystem.current.SetSelectedGameObject(mainMenuFirst);
    } 

    private void CloseAllMenus()
    {
        pauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion


    #region PauseActions
    public void toResume()
    {
        Unpause();
    }

    public void toRestart()
    {
        CloseAllMenus();
        Unpause();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

}
