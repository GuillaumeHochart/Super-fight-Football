using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Break_Component : MonoBehaviour, Break_component_action
{

    protected bool break_submit = false;

    public abstract bool checkUpdateState();

    public void changeState(bool update)
    {
        if (update)
        {
            break_submit = true;
            Debug.Log("submit input");
        }
    }

    public void checkAndUpdateStateComponent(Collision2D collision)
    {
        BreakableElement b = collision.gameObject.GetComponent<BreakableElement>();
        if (b != null && break_submit)
        {
            BreakableElement breakableElement = collision.gameObject.GetComponent<BreakableElement>();

            breakableElement.Dammage(10);
            break_submit = false;
        }
    }
}
