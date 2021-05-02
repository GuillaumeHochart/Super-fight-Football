using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace playerElement.abstractPlayer.component
{
    public class StaminaBar : NetworkBehaviour
    {
        public Slider slider;

        public void SetMaxStamina(float stamina)
        {
            slider.maxValue = stamina;
            slider.value = stamina;
        }

        public void SetStamina(float stamina)
        {
            slider.value = stamina;
        }

    }
}