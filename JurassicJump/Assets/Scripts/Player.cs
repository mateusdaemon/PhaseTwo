using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    
    private FloatingJoystick joystick;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<FloatingJoystick>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = joystick.Direction * speed;
    }
}
