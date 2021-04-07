using animation.minor;
using exception;
using playerElement.util;
using UnityEngine;

namespace playerElement.minor.action
{
    public class MinorMovement : PlayerMovement
    {
        public float moveSpeed;
        public float jumpForce;

        public int maxJumps = 3;
        private int _jumps;

        public new Rigidbody2D rigidbody2D;
        private Vector3 _velocity = Vector3.zero;


        private void Update()
        {
            if (_jumps != maxJumps)
            {
                Minor minor = GetComponent<Minor>();
                if (Input.GetMouseButton(1) && !minor.StateMinor.isLaunchable)
                {
                    minor.GetComponent<Rigidbody2D>().isKinematic = true;
                    minor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                else
                {
                    minor.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                JumpMove();
            }
        }

        private void FixedUpdate()
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

            MovePlayer(horizontalMovement);
        }


        private void MovePlayer(float horizontalMovement)
        {
            Minor minor = GetComponent<Minor>();
            if (Input.GetMouseButton(1))
            {
                minor.GetComponent<Rigidbody2D>().isKinematic = true;
                minor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else
            {
                minor.GetComponent<Rigidbody2D>().isKinematic = false;
                var velocity = rigidbody2D.velocity;
                Vector3 targetVelocity = new Vector2(horizontalMovement, velocity.y);
                rigidbody2D.velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref _velocity, .05f);
            }
        }


        private void JumpMove()
        {
            if (_jumps > 0)
            {
                rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                _jumps = _jumps - 1;
            }

            if (_jumps == 0)
            {
                return;
            }
        }

        private void OnCollisionEnter2D(Collision2D collider)
        {
            if (collider.gameObject.CompareTag("Ground"))
            {
                _jumps = maxJumps;
            }
        }
    }
}