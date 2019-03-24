using System;

[Serializable]
public class EquipmentInstance : ItemInstance
{
    public int level;
    public int experience;
    public bool equipped;

    public override void Use()
    {
        equipped = true;
    }
}