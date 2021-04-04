using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int maxJumps = 2;
    private int jumps;



    public Rigidbody2D rigidbody2D;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            JumpMove();
        }
    }
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
    }

    private void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidbody2D.velocity.y);
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity,ref velocity,.05f);
    }
    private void JumpMove()
    {

        if (jumps > 0)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
            jumps = jumps - 1;
        }
        if(jumps == 0)
        {
            return;
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            jumps = maxJumps;
        }
    }
}
