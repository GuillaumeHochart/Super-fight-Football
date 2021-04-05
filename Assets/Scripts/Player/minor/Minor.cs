using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minor : Player
{
    public int numbStockElement = 10;

    public Minor_Movment minor_Movment;

    private State_Minor state_minor;

    public Minor_Break_Component minor_Break_Component;

    public Minor_dispose_object minor_Dispose_Object;

    public State_Minor State_minor { get => state_minor; set => state_minor = value; }

    public Minor()
    {
        state_minor = new State_Minor();
    }

    public override Break_Component break_Component()
    {
        return minor_Break_Component;
    }

    public override Player_Movment player_movment()
    {
        return minor_Movment;
    }

}
