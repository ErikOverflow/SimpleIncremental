using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeSlot : MonoBehaviour
{
    PlayerUpgrade upgrade = null;
    [SerializeField]
    Image image = null;
    [SerializeField]
    TextMeshProUGUI upgradeNameText = null;

    public void CreateSlot(PlayerUpgrade _upgrade)
    {
        upgrade = _upgrade;
        UpdateSlot();
    }

    private void UpdateSlot()
    {
        image.sprite = upgrade.sprite;
        upgradeNameText.text = upgrade.name;
    }
}
