using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class WeaponMelee : Weapon
{
    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(new WeaponMeleeInstance(this));
    }
}

[System.Serializable]
public class WeaponMeleeInstance : WeaponInstance
{
    public float meleeLength = 5;

    public WeaponMeleeInstance(Item template) : base(template)
    {
        if (template != null)
        {
            item = template;
            templateName = template.name;
        }
    }
}