using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public PlayerMovement player;

    // Update is called once per frame
    void Update()
    {
        text.text = "Coins: " + player.coin.ToString();
    }
}
