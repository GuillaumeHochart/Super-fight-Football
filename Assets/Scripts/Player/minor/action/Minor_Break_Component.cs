using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minor_Break_Component : Break_Component
{
    void Update()
    {
        changeState(checkUpdateState());
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        checkAndUpdateStateComponent(collision);
    }

    public override bool checkUpdateState()
    {
        Minor minor = GetComponent<Minor>();

        return Input.GetMouseButtonDown(0) && minor.State_minor.IsDisposeObject;
    }
}
