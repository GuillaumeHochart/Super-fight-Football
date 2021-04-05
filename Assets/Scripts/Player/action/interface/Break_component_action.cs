using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Break_component_action 
{

    void changeState(bool update);

    void checkAndUpdateStateComponent(Collision2D collision);

}
