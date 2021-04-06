using System.Collections;
using System.Collections.Generic;
using Element;
using UnityEngine;

namespace playerElement
{
    public abstract class Player : BreakableElement , IPlayerAction
    {
        public abstract PlayerMovement PlayerMovement();

        public abstract BreakComponent BreakComponent();

    }
}

