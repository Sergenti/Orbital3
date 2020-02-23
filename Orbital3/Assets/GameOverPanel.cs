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

        // continue only if we are opening the panel
        if(!value) return; 

        // select the first button, for gamepad navigation of the UI
        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }
    }
}
