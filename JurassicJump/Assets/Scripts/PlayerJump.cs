using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    [Space(10)]
    [Header("Jump")]
    public Transform feetPos;
    public float checkRadios;
    public LayerMask whatIsGround;
    public float jumpSpeed = 20;
    public bool isGrounded = false;
    public bool isJumping = false;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    private PlayerState playerState;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadios, whatIsGround);
    }

    private void FixedUpdate()
    {
        if (!isGrounded || (isGrounded && isJumping))
        {
            HandleFalling();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            Invoke("Jumped", 0.5f);
            rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpSpeed);
            playerState.ChangeState(State.Jump);
        }
    }

    private void HandleFalling()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * (-fallMultiplier);
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * (-lowJumpMultiplier);
        }

        if (isGrounded && isJumping)
        {
            isJumping = false;
            playerState.ChangeState(State.None);
        }
    }

    private void Jumped()
    {
        isJumping = true;
    }

    private void OnDrawGizmos()
    {
        Collider2D isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadios, whatIsGround);

        if (isGrounded)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawWireSphere(feetPos.position, checkRadios);
    }
}
