using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WeaponMeleeController : MonoBehaviour
{
    public int damage = 0;
    List<CharacterHealth> chs = null;
    CharacterHealth[] iterableChs = null;

    private void OnDisable()
    {
        chs.Clear();
    }

    private void Awake()
    {
        chs = new List<CharacterHealth>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            iterableChs = chs.ToArray();
            foreach (CharacterHealth ch in iterableChs)
            {
                ch.TakeDamage(damage);
            }
        }
    }

    private void RemoveTarget(CharacterHealth ch)
    {
        chs.Remove(ch);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            CharacterHealth ch = collision.GetComponent<CharacterHealth>();
            if (ch != null)
            {
                chs.Add(ch);
                ch.UnTarget += RemoveTarget;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            CharacterHealth ch = collision.GetComponent<CharacterHealth>();
            if (ch != null && chs.Contains(ch))
                chs.Remove(ch);
        }
    }
}
