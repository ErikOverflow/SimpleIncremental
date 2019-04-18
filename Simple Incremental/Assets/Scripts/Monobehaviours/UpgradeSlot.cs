using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour, IDragHandler, IEndDragHandler
{
    PlayerUpgrade upgrade = null;
    [SerializeField]
    Image image = null;
    [SerializeField]
    Transform draggableObjectParent = null;
    Transform baseParent = null;
    List<RaycastResult> hitObjects = null;

    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(draggableObjectParent);
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(baseParent);
        EventSystem.current.RaycastAll(eventData, hitObjects);
        GameObject slotObject = hitObjects.FirstOrDefault(hO => hO.gameObject.GetComponentInChildren<UIEquippedUpgradeSlot>() != null).gameObject;
        if (slotObject != null)
        {
            UIEquippedUpgradesSubPanel.instance.EquipUpgrade(upgrade, slotObject.GetComponentInChildren<UIEquippedUpgradeSlot>());
        }
        transform.localPosition = Vector3.zero;
    }

    void Awake()
    {
        baseParent = transform.parent;
        hitObjects = new List<RaycastResult>();
    }

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
    }
}
