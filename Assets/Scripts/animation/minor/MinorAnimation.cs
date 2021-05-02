using System;
using exception;
using Mirror;
using playerElement.util;
using UnityEngine;

namespace animation.minor
{
    public class MinorAnimation : NetworkBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int PlayerIsLower = Animator.StringToHash("PlayerIsLower");

        public Animator animator;
        public SpriteRenderer spriteRenderer;

        public new Rigidbody2D rigidbody2D;

        private void FixedUpdate()
        {
            Flip();
            SetAnimation();
        }


        private void SetAnimation()
        {
            animator.SetFloat(Speed, Mathf.Abs(rigidbody2D.velocity.x));

            animator.SetBool(PlayerIsLower, Input.GetMouseButton(1));
        }

        private void Flip()
        {
            var velocity = rigidbody2D.velocity.x;
            if (Camera.main == null) throw new BussinesException("Camera is null");

            if (velocity > 0.1f)
            {
                spriteRenderer.flipX = false;
            }
            else if (velocity < -0.1f)
            {
                spriteRenderer.flipX = true;
            }

            if (Input.GetMouseButton(1))
            {
                Vector2 position = transform.position;
                Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spriteRenderer.flipX = !ClickUtils.ClickIsPlayerRight(position, mouse);
            }
        }
    }
}