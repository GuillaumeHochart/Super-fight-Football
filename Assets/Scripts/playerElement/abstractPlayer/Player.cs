using System;
using System.Collections;
using System.Collections.Generic;
using Element;
using Mirror;
using playerElement.abstractPlayer.component;
using UnityEngine;

namespace playerElement
{
    public abstract class Player : BreakableElement , IPlayerAction
    {
        public abstract PlayerMovement PlayerMovement();

        public abstract BreakComponent BreakComponent();


        /**Stamina**/
        public StaminaBar staminaBar;
        public int stamina = 10;
        public float currentStamina;
        //---------------------------------------------------------
        private float _staminaRegenTimer = 0.0f;
        private const float StaminaIncreasePerFrame = 1.0f;
        public float staminaTimeToRegen = 3.0f;

        public GameObject playerCamera;

        protected Player(){}
        public override void OnStartLocalPlayer()
        {
        }
        private void Start()
        {
 
            if (isLocalPlayer)
            {
                playerCamera.SetActive(true);
                currentStamina = stamina;
                if (staminaBar != null)
                {
                    staminaBar.SetMaxStamina(stamina);
                }
            }
            else
            {
                playerCamera.SetActive(false);
            }
        }

        private void Update()
        {
            if (_staminaRegenTimer >= staminaTimeToRegen)
            {
                currentStamina = Mathf.Clamp(currentStamina + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f,
                    stamina);
                staminaBar.SetStamina(currentStamina);
            }
            else
                _staminaRegenTimer += Time.deltaTime;

            //Debug.Log("CurrentStamina :"+currentStamina);
        }

        private bool CheckStamina(int costOfAction)
        {
            return currentStamina - costOfAction >= 0;
        }

        public bool CheckPossibleAction(int costOfAction)
        {
            Debug.Log("currentStamina : "+currentStamina);
            if (CheckStamina(costOfAction))
            {
                currentStamina = currentStamina - costOfAction;
                staminaBar.SetStamina(currentStamina);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

