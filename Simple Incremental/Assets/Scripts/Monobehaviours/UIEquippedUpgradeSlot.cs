using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquippedUpgradeSlot : MonoBehaviour
{
    public PlayerUpgrade upgrade = null;
    [SerializeField]
    Image image = null;

    public void ClearSlot()
    {
        upgrade = null;
        image.overrideSprite = null;
        image.enabled = false;
    }

    public void CreateSlot(PlayerUpgrade _upgrade)
    {
        if (_upgrade != null)
        {
            upgrade = _upgrade;
            image.enabled = true;
            image.overrideSprite = _upgrade.sprite;
        }
        else
        {
            ClearSlot();
        }
    }
}
