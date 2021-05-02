using UnityEngine;

namespace playerElement.minor.action
{
    public class Minor_Break_Component : BreakComponent
    {
        private void Update()
        {
            Minor minor = GetComponent<Minor>();
            if (minor.isLocalPlayer)
            {
                ChangeState(CheckUpdateState());
            }
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            Minor minor = GetComponent<Minor>();
            if (minor.isLocalPlayer)
            {
                CheckAndUpdateStateComponent(collision);
            }
        }

        public override bool CheckUpdateState()
        {
            Minor minor = GetComponent<Minor>();

            return minor.isLocalPlayer && Input.GetMouseButtonDown(0) && minor.stateMinor.IsDisposeObject;
        }
    }
}
