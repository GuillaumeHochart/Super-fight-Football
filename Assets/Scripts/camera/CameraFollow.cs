using UnityEngine;

namespace camera
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject player;

        public float timeOffset;
        public Vector3 postOffset;

        private Vector3 _velocity;

        void Update()
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + postOffset, ref _velocity, timeOffset);
        }
    }
}
