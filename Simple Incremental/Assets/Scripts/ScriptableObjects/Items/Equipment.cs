using System;
using System.Runtime.Serialization;

public class Equipment : Item
{
    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(new EquipmentInstance(this));
    }
}

[Serializable]
public class EquipmentInstance : ItemInstance
{
    public int equipmentNum1 = 1;
    public EquipmentInstance(Item template) : base(template)
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

    public virtual void UnEquip()
    {
        PlayerInventory.instance.UnEquipItem(this);
    }
}