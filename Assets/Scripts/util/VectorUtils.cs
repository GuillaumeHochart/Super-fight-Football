using System;
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
        public static Vector2 GetGroundPosition(Vector2 objectivePosition)
        {
            var down = new Vector2(0, Math.Abs(objectivePosition.y * 100) * -1);
            Debug.DrawRay(objectivePosition, down, Color.red);
            var hit = Physics2D.Raycast(objectivePosition, down);

            return hit.point;
        }
    }
    
}