using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatsSubPanel : SubPanelUI
{
    [SerializeField]
    TextMeshProUGUI levelText = null;
    [SerializeField]
    TextMeshProUGUI maxHealthText = null;
    [SerializeField]
    TextMeshProUGUI rangedAtkText = null;
    [SerializeField]
    TextMeshProUGUI meleeAtkText = null;

    PlayerLevel playerLevel = null;
    CharacterHealth characterHealth = null;
    PlayerWeaponRangedController rangedController = null;
    PlayerWeaponMeleeController meleeController = null;
    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        playerLevel = BackpackUI.instance.player.GetComponent<PlayerLevel>();
        characterHealth = BackpackUI.instance.player.GetComponent<CharacterHealth>();
        rangedController = BackpackUI.instance.player.GetComponent<PlayerWeaponRangedController>();
        meleeController = BackpackUI.instance.player.GetComponent<PlayerWeaponMeleeController>();
    }

    public override void UpdateUI()
    {
        levelText.text = "LVL: " + playerLevel.level.ToString();
        maxHealthText.text = "HP: " + characterHealth.maxHealth.ToString();
        if (rangedController.isActiveAndEnabled)
        {
            meleeAtkText.text = "Melee: -";
            rangedAtkText.text = "Ranged: " + rangedController.damage.ToString();
        }
        else if(meleeController.isActiveAndEnabled)
        {
            meleeAtkText.text = "Melee: " + meleeController.damage.ToString();
            rangedAtkText.text = "Ranged: -";
        }
    }
}
