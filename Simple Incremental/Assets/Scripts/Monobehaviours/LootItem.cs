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

    private void Start()
    {
        spriteRenderer.sprite = template.itemSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInventory>() != null)
        {
            InventoryItem item = template.GenerateNewItem();
            PlayerInventory.instance.items.Add(item);
            gameObject.SetActive(false);
        }
    }

    private void OnValidate()
    {
        if(template != null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = template.itemSprite;
        }
    }
}
