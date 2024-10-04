using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private HudManager hudManager;
    public Vector2 MovementInputDirection {  get; private set; }
    public event Action OnJump;
    
    private FloatingJoystick joystick;

    void Start()
    {
        hudManager = FindObjectOfType<HudManager>();
        joystick = FindObjectOfType<FloatingJoystick>();
        hudManager.JumpBtn.onClick.AddListener(HandleJump);
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

    private void HandleJump()
    {
        OnJump.Invoke();
    }
}
