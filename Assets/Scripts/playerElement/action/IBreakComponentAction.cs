using UnityEngine;

namespace playerElement.action
{
    public interface IBreakComponentAction 
    {

        void ChangeState(bool update);

        void CheckAndUpdateStateComponent(Collision2D collision);

    }
}

