using UnityEngine;

namespace playerElement.minor.action
{
    public class MinorMovement : PlayerMovement
    {
        public float moveSpeed;
        public float jumpForce;

        public int maxJumps = 2;
        private int _jumps;

        public Animator animator;
        public SpriteRenderer spriteRenderer;
        public new Rigidbody2D rigidbody2D;
        private Vector3 _velocity = Vector3.zero;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                JumpMove();
            }
        }

        private void FixedUpdate()
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

            MovePlayer(horizontalMovement);
            
            Flip(rigidbody2D.velocity.x);

            animator.SetFloat(Speed, Mathf.Abs(rigidbody2D.velocity.x));
        }

        private void MovePlayer(float horizontalMovement)
        {
            var velocity = rigidbody2D.velocity;
            Vector3 targetVelocity = new Vector2(horizontalMovement, velocity.y);
            rigidbody2D.velocity = Vector3.SmoothDamp(velocity, targetVelocity,ref _velocity,.05f);
        }
        private void JumpMove()
        {

            if (_jumps > 0)
            {
                rigidbody2D.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
                _jumps = _jumps - 1;
            }
            if(_jumps == 0)
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

        private void Flip(float velocity)
        {
            if(velocity > 0.1f)
            {
                spriteRenderer.flipX = false;
            }else if(velocity < -0.1f)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}
