using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class LootItem : MonoBehaviour
{
    SpriteRenderer spriteRenderer = null;
    public Item template = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = template.sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInventory>() != null)
        {
            ItemInstance item = ItemInstance.GetItemInstance(template);
            PlayerInventory.instance.items.Add(item);
            gameObject.SetActive(false);
        }
    }

    private void OnValidate()
    {
        if(template != null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = template.sprite;
        }
    }
}
