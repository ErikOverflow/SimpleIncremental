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
}