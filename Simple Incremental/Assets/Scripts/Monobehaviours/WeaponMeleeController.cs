using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeController : MonoBehaviour
{
    public int damage = 0;
    [NonSerialized]
    public GameObject weapon;
    [SerializeField]
    LayerMask mask;
    ContactFilter2D cf2d;
    Collider2D[] colliders;
    Animator anim;
    bool canAttack;
    List<CharacterHealth> damagedCharacters = new List<CharacterHealth>();

    private void OnDisable()
    {
        canAttack = true;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        cf2d = new ContactFilter2D();
        cf2d.layerMask = mask;
        cf2d.useLayerMask = true;
        colliders = new Collider2D[10];
        canAttack = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            StartCoroutine(CheckForAttacking());
        }
    }

    private IEnumerator CheckForAttacking()
    {
        if (canAttack)
        {
            canAttack = false;
            damagedCharacters.Clear();
            while (anim.GetBool("Attacking"))
            {
                weapon.GetComponent<Collider2D>().OverlapCollider(cf2d, colliders);
                foreach (Collider2D col in colliders)
                {
                    CharacterHealth ch = col?.GetComponent<CharacterHealth>();
                    if (!damagedCharacters.Contains(ch))
                    {
                        ch?.TakeDamage(damage);
                        damagedCharacters.Add(ch);
                    }
                }
                yield return new WaitForFixedUpdate();
            }
            canAttack = true;
        }
    }
}
