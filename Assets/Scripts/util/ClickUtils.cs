using exception;
using UnityEngine;

namespace playerElement.util
{
    public static class ClickUtils
    {
        public static bool ClickIsPlayerRight(Vector3 playerPosition , Vector3 mousePosition)
        {
            if (playerPosition == null)
            {
                throw new BussinesException("player position is null");
            }

            if (mousePosition == null)
            {
                throw new BussinesException("mouse position is null");
            }

            return playerPosition.x < mousePosition.x;
        }
    }
}