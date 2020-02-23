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
        
        public void OneMoreDead()
        {
            if (CheckEndConditions())
            {
                PlayerStats winner = GetFirstAlive();
                string name = winner.name;
                Color color = winner.color;
                //Call stuff from flo                
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