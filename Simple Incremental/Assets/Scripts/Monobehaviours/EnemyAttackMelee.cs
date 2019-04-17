using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{
    Rigidbody2D rb2d = null;
    public int damage = 1;
    public float punchForce = 200f;
    private Animator anim;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void StartAttacking()
    {
        anim.SetTrigger("AttackMelee");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterHealth ch = collision.gameObject.GetComponent<CharacterHealth>();
            Vector2 forcePush = (ch.transform.position - transform.position).normalized;
            Rigidbody2D targetRb2d = ch.GetComponent<Rigidbody2D>();
            targetRb2d?.AddForce(forcePush * punchForce);
            rb2d?.AddForce(-forcePush * punchForce);
            ch.TakeDamage(damage);
        }
    }
}
