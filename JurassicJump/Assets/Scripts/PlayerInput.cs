using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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
        hudManager.JumpBtn.onClick.AddListener(HandleJump);
        joystick = FindObjectOfType<FloatingJoystick>();
    }

    void Update()
    {
        GetMoveInput();
    }

    private void GetMoveInput()
    {
        if (joystick != null && Mathf.Abs(joystick.Direction.x) > 0.1f)
        {
            MovementInputDirection = new Vector2(joystick.Direction.x, 0);
        } 
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            MovementInputDirection = new Vector2(horizontalInput, 0);
        }

        MovementInputDirection.Normalize();
    }

    private void HandleJump()
    {
        OnJump.Invoke();
    }
}
