using System;
using System.Runtime.Serialization;

[System.Serializable]
public class Weapon : Equipment
{
    public int damage;

    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(new WeaponInstance(this));
    }
}

[System.Serializable]
public class WeaponInstance : EquipmentInstance
{
    public float weaponFloat1 = 0.5f;

    public WeaponInstance(Item template) : base(template)
    {
        if (template != null)
        {
            item = template;
            templateName = template.name;
        }
    }

    public override void Clicked()
    {
        PlayerInventory.instance.EquipItem(this);
    }

    public override void UnEquip()
    {
        PlayerInventory.instance.UnEquipItem(this);
    }
}