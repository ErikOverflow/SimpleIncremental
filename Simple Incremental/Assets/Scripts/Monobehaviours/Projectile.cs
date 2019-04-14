using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Projectile : MonoBehaviour
{
    Rigidbody2D rb2d = null;
    SpriteRenderer spriteRenderer = null;
    int damage = 0;
    float falloffTime = 0f;
    int maxPenetrations = 1;

    [SerializeField]
    LayerMask stopLayers;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Launch(Vector2 direction, Sprite _sprite, int _damage, float _falloffTime, int _maxPenetrations, float _force, float _torque)
    {
        gameObject.SetActive(true);
        spriteRenderer.sprite = _sprite;
        damage = _damage;
        falloffTime = _falloffTime;
        maxPenetrations = _maxPenetrations;
        rb2d.AddTorque(_torque);
        rb2d.AddForce(direction.normalized * _force);
        StartCoroutine(Lifetime());
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(falloffTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            CharacterHealth ch = collision.gameObject.GetComponent<CharacterHealth>();
            if (ch != null)
            {
                if (maxPenetrations-- > 0)
                {
                    ch.TakeDamage(damage);
                }
                if (maxPenetrations <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        //Collided with Ground
        if (((1<<collision.gameObject.layer) & stopLayers) != 0)
        {
            rb2d.angularVelocity = 0;
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
