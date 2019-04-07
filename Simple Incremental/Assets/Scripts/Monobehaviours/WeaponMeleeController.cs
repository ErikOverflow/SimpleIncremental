using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeController : MonoBehaviour
{
    public int damage = 0;
    [NonSerialized]
    public GameObject weapon;
    [SerializeField]
    ContactFilter2D cf2d = new ContactFilter2D();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            Collider2D[] colliders = new Collider2D[5];
            weapon.GetComponent<Collider2D>().OverlapCollider(cf2d, colliders);
            foreach (Collider2D col in colliders)
            {
                col?.GetComponent<CharacterHealth>()?.TakeDamage(damage);
            }
        }
    }
}
