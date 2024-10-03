using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private PlayerState playerState;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerState = GetComponent<PlayerState>();
    }

    public void SetAnim(Vector2 direction)
    {
        animator.SetBool("walk", false);
        animator.SetBool("jump", false);
        animator.SetBool("idle", false);

        switch (playerState.State)
        {
            case State.Walk:
                animator.SetBool("walk", true);
                break;
            case State.Jump:
                animator.SetBool("jump", true);
                break;
            case State.Idle:
                animator.SetBool("idle", true);
                break;
        }
    }
}
