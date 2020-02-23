using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    public void SetWinner(string winner, Color color)
    {
        playerName.text = winner + "'s";
        playerName.color = color;
    }
}
