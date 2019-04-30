using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{
    public int damage = 1;
    public float punchForce = 200f;
    Rigidbody2D rb2d = null;
    Animator anim = null;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterHealth ch = collision.gameObject.GetComponent<CharacterHealth>();
        if (ch != null)
        {
            Rigidbody2D targetRb2d = ch.GetComponent<Rigidbody2D>();
            Vector2 forcePush = (ch.transform.position - transform.position).normalized;
            targetRb2d?.AddForce(forcePush * punchForce);
            rb2d?.AddForce(-forcePush * punchForce);
            ch.TakeDamage(damage);
        }
    }
}
