using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Walk,
    Jump,
    Idle
}


public class PlayerState : MonoBehaviour
{
    public State State {  get; private set; }

    public void ChangeState(State state)
    {
        switch (state)
        {
            case State.Walk:
                State = State.Walk;
                break;
            case State.Jump:
                State = State.Jump;
                break;
            case State.Idle:
                State = State.Idle;
                break;
        }
    }
}
