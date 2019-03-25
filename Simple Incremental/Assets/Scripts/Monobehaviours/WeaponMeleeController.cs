using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WeaponMeleeController : MonoBehaviour
{
    public int damage = 0;
    Collider2D meleeTrigger = null;

    Camera mainCam;

    public void Awake()
    {
        mainCam = Camera.main;
        meleeTrigger = GetComponent<Collider2D>();
        meleeTrigger.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        meleeTrigger.enabled = true;
        yield return new WaitForFixedUpdate();
        meleeTrigger.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            CharacterHealth ch = collision.GetComponent<CharacterHealth>();
            ch?.TakeDamage(damage);
        }
    }
}
