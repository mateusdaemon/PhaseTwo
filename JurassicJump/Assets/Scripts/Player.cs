using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerInput playerInput;
    private PlayerRender PlayerRender;
    private PlayerAnim playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerInput = GetComponent<PlayerInput>();
        PlayerRender = GetComponent<PlayerRender>();
        playerAnim = GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer(playerInput.MovementInputDirection);
    }

    private void MovePlayer(Vector2 direction)
    {
        playerMove.Move(direction);
        playerAnim.SetAnim(direction);
        PlayerRender.Render(direction);
    }
}
