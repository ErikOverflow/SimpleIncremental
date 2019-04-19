using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatsSubPanel : UISubPanel
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
        playerLevel = UIBackpack.instance.player.GetComponent<PlayerLevel>();
        characterHealth = UIBackpack.instance.player.GetComponent<CharacterHealth>();
        rangedController = UIBackpack.instance.player.GetComponent<PlayerWeaponRangedController>();
        meleeController = UIBackpack.instance.player.GetComponent<PlayerWeaponMeleeController>();
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
