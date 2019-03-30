
[System.Serializable]
public class Weapon : Equipment
{
    public int damage;

    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(ScriptableInstantiate(this));
    }

    public override void Use()
    {
        PlayerInventory.instance.EquipWeapon(this);
    }
}