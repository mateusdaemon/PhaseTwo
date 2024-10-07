using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private IDamageable damageable;

    void Start()
    {
        damageable = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && damageable != null)
        {
            damageable.TakeDamage(1);
        }
    }
}
