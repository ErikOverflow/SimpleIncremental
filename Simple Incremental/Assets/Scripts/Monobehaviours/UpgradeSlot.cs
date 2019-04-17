using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour
{
    PlayerUpgrade upgrade = null;
    [SerializeField]
    Image image = null;

    public void ClearSlot()
    {
        upgrade = null;
        image.overrideSprite = null;
    }

    public void CreateSlot(PlayerUpgrade _upgrade)
    {
        if (_upgrade != null)
        {
            image.overrideSprite = upgrade.sprite;
        }
    }
}
