using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class WeaponRanged : Weapon
{
    public Sprite projectileSprite;
    public float projectileSpeed;
    public int maxHits;
    public float falloffTime;
    public float projectileRotation;
}