using System.Collections;
using System.Collections.Generic;
using Element;
using playerElement.action;
using UnityEngine;

namespace playerElement
{
    public abstract class BreakComponent : MonoBehaviour, IBreakComponentAction
    {

        protected bool BreakSubmit = false;

        public abstract bool CheckUpdateState();

        public void ChangeState(bool update)
        {
            if (!update) return;
            BreakSubmit = true;
            Debug.Log("submit input");
        }

        public void CheckAndUpdateStateComponent(Collision2D collision)
        {
            var b = collision.gameObject.GetComponent<BreakableElement>();
            if (b == null || !BreakSubmit) return;
            var breakableElement = collision.gameObject.GetComponent<BreakableElement>();

            breakableElement.RemoveLifeOnBreakableElement(10);
            BreakSubmit = false;
        }
    }
}

