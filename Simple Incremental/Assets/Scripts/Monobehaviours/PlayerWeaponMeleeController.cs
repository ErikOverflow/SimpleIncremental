using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponMeleeController : MonoBehaviour
{
    public int damage = 0;
    [SerializeField]
    LayerMask mask = new LayerMask();
    ContactFilter2D cf2d;
    Collider2D[] colliders;
    [NonSerialized]
    public Collider2D weaponCollider;

    private void Awake()
    {
        cf2d = new ContactFilter2D();
        cf2d.layerMask = mask;
        cf2d.useLayerMask = true;
        colliders = new Collider2D[10];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            weaponCollider.OverlapCollider(cf2d, colliders);
            foreach (Collider2D col in colliders)
            {
                CharacterHealth ch = col?.GetComponent<CharacterHealth>();
                ch?.TakeDamage(damage);
            }
        }
    }
}
