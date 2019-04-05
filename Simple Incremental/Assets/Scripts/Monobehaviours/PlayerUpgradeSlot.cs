using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeSlot : MonoBehaviour
{
    PlayerUpgrade upgrade = null;
    [SerializeField]
    Image image = null;

    public void Clicked()
    {
        upgrade.Applied = true;
        upgrade.LevelUp();
    }

    public void CreateSlot(PlayerUpgrade _upgrade)
    {
        upgrade = _upgrade;
        image.sprite = upgrade.sprite;
    }
}
