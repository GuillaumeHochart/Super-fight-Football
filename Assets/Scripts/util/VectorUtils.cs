using UnityEngine;

namespace playerElement.util
{
    public static class VectorUtils
    {
        public static Vector2 LerpByDistance(Vector2 playerPosition, Vector2 mousePosition, float x)
        {
            Vector2 ba = mousePosition - playerPosition;
            Vector2 baNormalize = Vector3.Normalize(ba);
            Vector2 force = x * baNormalize;

            Vector2 p = force + playerPosition;
            return p;
        }
    }
}