using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Element
{
    public class BreakableElement : NetworkBehaviour
    {
        public int life = 1;

        public void RemoveLifeOnBreakableElement(int damage)
        {
            Debug.Log("Life actuel : " + life);
            Debug.Log("Damage : " + damage);

            life -= damage;
            if (!CheckIsDeath()) return;
            Debug.Log(gameObject.name + " is death");

            gameObject.SetActive(false);
        }

        private bool CheckIsDeath()
        {
            return life <= 0;
        }
    }
}
