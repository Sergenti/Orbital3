using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private GameObject firstSelectedButton;
    public void SetWinner(string winner, Color color)
    {
        playerName.text = winner + "'s";
        playerName.color = color;
    }

    public void Enable(bool value)
    {
        gameObject.SetActive(value);

        if (value)
        {
            Debug.Log("Set first button.");
            // select first button for keyboard and gamepad navigation
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }
    }
}
