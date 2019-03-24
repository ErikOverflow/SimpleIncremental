using System;

[Serializable]
public class EquipmentInstance : ItemInstance
{
    public int level;
    public int experience;
    public bool equipped;

    public EquipmentInstance(Equipment _item)
    {
        item = _item;
    }

    public override void Use()
    {
        equipped = !equipped;
    }
}