using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterHealth))]
public class CharacterHealthUI : MonoBehaviour
{
    CharacterHealth characterHealth;
    [SerializeField]
    Transform healthBar = null;


    private void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        characterHealth.HealthChanged += UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        Vector3 scale = healthBar.localScale;
        scale.x = (float)characterHealth.health / characterHealth.maxHealth;
        healthBar.localScale = scale;
    }
}
