using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathText : MonoBehaviour
{
    public TextMeshProUGUI deathText;
    // Start is called before the first frame update
    void Start()
    {
        deathText.text = "Total Deaths: " + PlayerPrefs.GetInt("deathAmt").ToString();
    }
}
