using UnityEngine;

namespace playerElement.minor.action
{
    public class Minor_Break_Component : BreakComponent
    {
        private void Update()
        {
            ChangeState(CheckUpdateState());
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            CheckAndUpdateStateComponent(collision);
        }

        public override bool CheckUpdateState()
        {
            Minor minor = GetComponent<Minor>();

            return Input.GetMouseButtonDown(0) && minor.stateMinor.IsDisposeObject;
        }
    }
}
