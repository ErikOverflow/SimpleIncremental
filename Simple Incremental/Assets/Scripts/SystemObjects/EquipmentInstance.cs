using System;

[Serializable]
public class EquipmentInstance : ItemInstance
{
    public int level;
    public int experience;

    public EquipmentInstance(Equipment _item)
    {
        item = _item;
    }

    public override void Use()
    {
        PlayerInventory.instance.EquipWeapon(this);
    }
}