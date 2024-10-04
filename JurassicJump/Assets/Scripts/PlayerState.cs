using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum State
{
    Walk,
    Jump,
    Idle,
    None
}


public class PlayerState : MonoBehaviour
{
    public State State { get; private set; }

    // Usa Action para definir um evento de mudança de estado
    public event Action<State> OnStateChange;

    private void Start()
    {
        State = State.None;
    }

    public void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.Jump:
                State = State.Jump;
                break;
            case State.Walk:
                if (State != State.Jump)
                {
                    State = State.Walk;
                }
                break;
            case State.Idle:
                if (State != State.Jump)
                {
                    State = State.Idle;
                }
                break;
            case State.None:
                State = newState;
                break;
        }

        OnStateChange.Invoke(State);
    }
}
