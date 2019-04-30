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
    [SerializeField]
    Transform healthBarContainer = null;

    private void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        characterHealth.HealthChanged += UpdateHealthUI;
        characterHealth.OnDeath += DisableHealthBar;
    }

    private void UpdateHealthUI()
    {
        Vector3 scale = healthBar.localScale;
        if (characterHealth.maxHealth > 0)
            scale.x = (float)characterHealth.health / characterHealth.maxHealth;
        else
            scale.x = 0;
        healthBar.localScale = scale;
    }
    private void DisableHealthBar()
    {
        healthBarContainer.gameObject.SetActive(false);
    }
}
