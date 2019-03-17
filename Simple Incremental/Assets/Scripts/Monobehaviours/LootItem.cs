using SimpleIncremental.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class LootItem : MonoBehaviour
{
    SpriteRenderer spriteRenderer = null;
    [SerializeField]
    ItemTemplate template = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInventory>() != null)
        {
            PlayerInventory.instance.items.Add(template.GenerateNewItem());
            gameObject.SetActive(false);
        }
    }
}
