using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!PlayerPrefs.HasKey("deathAmt")) PlayerPrefs.SetInt("deathAmt", 1);
            else PlayerPrefs.SetInt("deathAmt", PlayerPrefs.GetInt("deathAmt") + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
