using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : BreakableElement , Player_action
{
    public abstract Player_Movment player_movment();

    public abstract Break_Component break_Component();

}
