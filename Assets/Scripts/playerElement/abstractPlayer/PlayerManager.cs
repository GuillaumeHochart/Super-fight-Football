using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace playerElement
{
    public class PlayerManager : NetworkBehaviour
    {
        public PlayerMovement playerMovement;

        public static PlayerManager Instance { get; private set; } //static singleton

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else { Destroy(gameObject); }

            playerMovement = FindObjectOfType<PlayerMovement>();
        }

    }
    
}

