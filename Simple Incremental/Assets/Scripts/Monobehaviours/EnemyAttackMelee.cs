using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{
    [SerializeField]
    LayerMask mask = new LayerMask();
    Rigidbody2D rb2d = null;
    public int damage = 1;
    public float punchForce = 200f;
    [HideInInspector]
    public GameObject weapon = null;
    private Animator anim;
    private bool canAttack = true;
    private float meleeCooldown = 0.5f;
    ContactFilter2D cf2d;
    Collider2D[] colliders;
    List<CharacterHealth> damagedCharacters = new List<CharacterHealth>();


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cf2d = new ContactFilter2D();
        cf2d.layerMask = mask;
        cf2d.useLayerMask = true;
        colliders = new Collider2D[10];
    }

    private IEnumerator ResetCanAttack()
    {
        
        yield return new WaitForSeconds(meleeCooldown);
        canAttack = true;
}

    public void StartAttacking()
    {
        if (!canAttack)
            return;
        canAttack = false;
        anim.SetTrigger("AttackMelee");

        BoxCollider2D collider = weapon.gameObject.GetComponent<BoxCollider2D>();
        collider.OverlapCollider(cf2d, colliders);
        foreach (Collider2D col in colliders)
        {
            CharacterHealth ch = col?.GetComponent<CharacterHealth>();
            if (!damagedCharacters.Contains(ch) && ch != null)
            {
                ch?.TakeDamage(damage);
                damagedCharacters.Add(ch);
            }
        }
        damagedCharacters.Clear();
        StartCoroutine(ResetCanAttack());
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
