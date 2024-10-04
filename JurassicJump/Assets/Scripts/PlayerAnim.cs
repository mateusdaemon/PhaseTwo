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

        playerState.OnStateChange += SetAnim;
    }

    public void SetAnim(State state)
    {
        switch (state)
        {
            case State.Walk:
                animator.SetBool("walk", true);
                animator.SetBool("idle", false);
                animator.SetBool("jump", false);
                break;
            case State.Jump:
                animator.SetBool("jump", true);
                animator.SetBool("walk", false);
                animator.SetBool("idle", false);
                break;
            case State.Idle:
                animator.SetBool("idle", true);
                animator.SetBool("walk", false);
                animator.SetBool("jump", false);
                break;
            case State.None:
                break;
        }
    }
}
