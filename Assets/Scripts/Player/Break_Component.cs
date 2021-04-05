using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Component : MonoBehaviour
{

    bool break_submit = false;


    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            break_submit = true;
            Debug.Log("submit input");
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        BreakableElement b=collision.gameObject.GetComponent<BreakableElement>();
        if (b != null && break_submit)
        {
            BreakableElement breakableElement = collision.gameObject.GetComponent<BreakableElement>();

            breakableElement.Dammage(10);
            break_submit = false;
        }

    }
}
