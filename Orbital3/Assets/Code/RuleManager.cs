using System.Collections.Generic;
using Code.EventSystem;
using Code.EventSystem.Events;
using Code.Movement;
using UnityEngine;

namespace Code
{
    public class RuleManager : MonoBehaviour
    {

        [SerializeField] private List<PlayerStats> players;
        [SerializeField] private GameOverPanel _gameOverPanel;
        
        private void Update()
        {
            if (CheckEndConditions())
            {
                PlayerStats winner = GetFirstAlive();
                string name = winner.playerName;
                Color color = winner.color;
                _gameOverPanel.gameObject.SetActive(true); 
                _gameOverPanel.SetWinner(name,color);
                Destroy(gameObject);
            }
        }

        private bool CheckEndConditions()
        {
            bool oneAlive = false;
            
            foreach (var player in players)
            {
                if (player.isAlive && oneAlive)
                    return false;
                if(player.isAlive)
                    oneAlive = true;
            }

            return true;
        }

        private PlayerStats GetFirstAlive()
        {
            foreach (PlayerStats player in players)
            {
                if (player.isAlive)
                    return player;
            }

            return players[0];
        }
    }
}