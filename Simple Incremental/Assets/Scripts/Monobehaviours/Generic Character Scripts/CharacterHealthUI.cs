using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterHealth))]
public class CharacterHealthUI : MonoBehaviour
{
    CharacterHealth characterHealth;
    Slider healthBarSlider;
    TextMeshProUGUI healthBarText;
    [SerializeField]
    GameObject healthBarPrefab = null;
    [SerializeField]
    Transform healthBarsContainer = null;
    Camera mainCamera;

    private void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        mainCamera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        characterHealth.HealthChanged += UpdateHealthUI;
        characterHealth.OnDeath += Disable;
    }

    private void Update()
    {
        healthBarSlider.transform.position = mainCamera.WorldToScreenPoint(characterHealth.transform.position + Vector3.up * 2);
    }

    private void GenerateHealthBar()
    {
        GameObject healthBar = ObjectPooler.instance.GetPooledObject(healthBarPrefab);
        healthBarSlider = healthBar.GetComponent<Slider>();
        healthBarText = healthBar.GetComponentInChildren<TextMeshProUGUI>();
        healthBarSlider.transform.SetParent(healthBarsContainer);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthBarSlider == null)
            GenerateHealthBar();
        healthBarSlider.maxValue = characterHealth.maxHealth;
        healthBarSlider.value = characterHealth.health;
        healthBarText.text = characterHealth.health + "/" + characterHealth.maxHealth;
    }

    private void Disable()
    {
        healthBarSlider.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        characterHealth.HealthChanged -= UpdateHealthUI;
    }
}
