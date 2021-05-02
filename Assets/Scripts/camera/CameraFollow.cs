using Mirror;
using playerElement;
using UnityEngine;

namespace camera
{
    public class CameraFollow : MonoBehaviour
    {
        public float timeOffset;
        public Vector3 postOffset;

        private Vector3 _velocity;

        public Player player;

        void Update()
        {

            if (player.isLocalPlayer)
            {
                transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + postOffset,
                    ref _velocity, timeOffset);
            }
        }
    }
}
