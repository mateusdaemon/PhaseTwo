using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private FloatingJoystick joystick;
    public Vector2 MovementInputDirection {  get; private set; }

    void Start()
    {
        joystick = FindObjectOfType<FloatingJoystick>();
    }

    void Update()
    {
        GetMoveInput();
    }

    private void GetMoveInput()
    {
        MovementInputDirection = joystick.Direction;
        MovementInputDirection.Normalize();
    }
}
