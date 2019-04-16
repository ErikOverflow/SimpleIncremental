using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponMeleeController : MonoBehaviour
{
    public int damage = 0;
    [NonSerialized]
    public GameObject weapon;
    [SerializeField]
    LayerMask mask = new LayerMask();
    ContactFilter2D cf2d;
    Collider2D[] colliders;
    Animator anim;
    bool canAttack;
    List<CharacterHealth> damagedCharacters = new List<CharacterHealth>();
    int meleeAttackingHash = Animator.StringToHash("MeleeAttacking");
    int meleeAttackHash = Animator.StringToHash("MeleeAttack");

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
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool(meleeAttackingHash, false);
        }
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            anim.SetBool(meleeAttackingHash, true);
            StartCoroutine(CheckForAttacking());
        }
    }

    //Called from Animation so multiple hitts can occur when mouse is held down
    public void AttackClear()
    {
        damagedCharacters.Clear();
    }

    private IEnumerator CheckForAttacking()
    {
        if (canAttack)
        {
            canAttack = false;
            BoxCollider2D collider = weapon.gameObject.AddComponent<BoxCollider2D>();
            while (anim.GetBool(meleeAttackingHash))
            {
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

                yield return new WaitForFixedUpdate();
            }
            Destroy(weapon.GetComponent<Collider2D>());
            canAttack = true;
        }
    }
}
