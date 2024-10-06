using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerInput playerInput;
    private PlayerRender PlayerRender;
    private PlayerJump playerJump;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerInput = GetComponent<PlayerInput>();
        PlayerRender = GetComponent<PlayerRender>();
        playerJump = GetComponent<PlayerJump>();
        playerInput.OnJump += playerJump.Jump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerMove.Move(playerInput.MovementInputDirection);
        PlayerRender.Render(playerInput.MovementInputDirection);
    }
}
