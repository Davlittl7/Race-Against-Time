using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI livesText;
    public PlayerMovement player;

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + player.coin.ToString();
        livesText.text = "Lives: " + player.lives.ToString();
    }
}
