using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoot : MonoBehaviour
{
    public int coins = 10;
    public Item[] items = null;
    public float lootChance = 0.1f;
    [SerializeField]
    GameObject lootPrefab = null;

    CharacterHealth characterHealth = null;

    private void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
    }

    private void Start()
    {
        characterHealth.OnDeath += CalculateAndDropLoot;
    }

    private void CalculateAndDropLoot()
    {
        foreach(Item item in items)
        {
            if(lootChance >= Random.Range(0f, 1f))
            {
                GameObject go = ObjectPooler.instance.GetPooledObject(lootPrefab);
                go.transform.position = transform.position;
                go.GetComponent<LootItem>().template = item;
            }
        }
    }
}
