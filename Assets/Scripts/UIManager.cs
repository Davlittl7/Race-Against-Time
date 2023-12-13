using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI lapseText;
    public PlayerMovement player;

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + player.coin.ToString();
        lapseText.text = "Time Lapses: " + player.timeLapse.ToString();
    }
}
