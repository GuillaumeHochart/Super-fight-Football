using System.Collections;
using System.Collections.Generic;
using exception;
using Mirror;
using UnityEngine;

namespace playerElement
{
    public class PlayerMovement : MonoBehaviour
    {
        public new Rigidbody2D rigidbody2D;

        private Vector2 _velocity = Vector2.zero;

        protected void MovePlayer(Player player, float horizontalMovement)
        {
            if (player == null)
            {
                throw new BussinesException("player is null");
            }
            
            if (Input.GetMouseButton(1))
            {
                player.GetComponent<Rigidbody2D>().isKinematic = true;
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else
            {
                player.GetComponent<Rigidbody2D>().isKinematic = false;
                var velocity = rigidbody2D.velocity;
                Vector2 targetVelocity = new Vector2(horizontalMovement, velocity.y);
                rigidbody2D.velocity = Vector2.SmoothDamp(velocity, targetVelocity, ref _velocity, .05f);
            }
        }
    }
}