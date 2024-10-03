using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRender : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    public bool IsSpriteFlipped { get => spriteRender.flipX; }

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    public void Render(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) != 0)
        {
            spriteRender.flipX = Vector3.Dot(transform.right, direction) < 0;
        }
    }
}
