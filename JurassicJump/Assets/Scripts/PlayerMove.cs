using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private float speed = 10;
    private PlayerState playerState;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    public void Move(Vector2 direction)
    {

        if (Mathf.Abs(direction.x) != 0)
        {
            playerState.ChangeState(State.Walk);
        } else
        {
            playerState.ChangeState(State.Idle);
        }

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }
}
