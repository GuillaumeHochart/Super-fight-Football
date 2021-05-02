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
        
        private void Update()
        {
            Minor minor = GetComponent<Minor>();

            if (minor.isLocalPlayer)
            {
                if (minor.stateMinor.RemainingJump != maxJumps)
                {
                    if (Input.GetMouseButton(1) && !minor.stateMinor.IsLaunchable)
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
                    JumpMove(minor);
                }
            }
        }

        private void FixedUpdate()
        {
            Minor minor = GetComponent<Minor>();

            if (minor.isLocalPlayer)
            {
                float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

                MovePlayer(minor, horizontalMovement);
            }
        }

        private void JumpMove(Minor minor)
        {
            if (minor == null) {throw new BussinesException("Minor is null");}
            
            if (minor.stateMinor.RemainingJump > 0)
            {
                rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                minor.stateMinor.RemainingJump = minor.stateMinor.RemainingJump - 1;
            }

            if (minor.stateMinor.RemainingJump == 0)
            {
                return;
            }
        }

        private void OnCollisionEnter2D(Collision2D collider)
        {
            Minor minor = GetComponent<Minor>();

            if (minor.isLocalPlayer)
            {
                if (collider.gameObject.CompareTag("Ground"))
                {
                    minor.stateMinor.RemainingJump = maxJumps;
                }
            }
        }
    }
}