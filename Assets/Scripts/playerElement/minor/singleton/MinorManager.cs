using Mirror;
using UnityEngine;

namespace playerElement.minor.singleton
{
    public class MinorManager : NetworkBehaviour
    {
        public Minor minor;

        public static MinorManager Instance { get; private set; } //static singleton

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else { Destroy(gameObject); }

            minor = FindObjectOfType<Minor>();
        }
    }
}
