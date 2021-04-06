using System.Collections;
using System.Collections.Generic;
using playerElement;
using UnityEngine;

namespace playerElement
{
    public interface IPlayerAction
    {
        PlayerMovement PlayerMovement();

        BreakComponent BreakComponent(); 
    }
}

