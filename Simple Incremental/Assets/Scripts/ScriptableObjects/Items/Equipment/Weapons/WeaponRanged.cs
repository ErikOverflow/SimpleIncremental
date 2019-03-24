using UnityEngine;

[CreateAssetMenu]
public class WeaponRanged : Weapon
{
    public Sprite projectileSprite;
    public float projectileSpeed;
    public int maxHits;
    public float falloffTime;
}