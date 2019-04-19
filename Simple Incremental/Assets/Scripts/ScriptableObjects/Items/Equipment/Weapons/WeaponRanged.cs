using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class WeaponRanged : Weapon
{
    public Sprite projectileSprite;
    public float projectileLaunchForce = 300f;
    public int maxHits;
    public float falloffTime;
    public float projectileTorque = 5f;

    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(new WeaponRangedInstance(this));
    }
}

[System.Serializable]
public class WeaponRangedInstance : WeaponInstance
{
    public float rangedValue = 20;

    public WeaponRangedInstance(Item template) : base(template)
    {
        if (template != null)
        {
            item = template;
            templateName = template.name;
        }
    }
}