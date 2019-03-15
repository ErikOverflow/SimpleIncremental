using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponTemplate : ScriptableObject
{
    public Sprite sprite = null;
    public Sprite projectileSprite = null;
    public float projectileSpeed = 1f;
    public int maxPenetrations = 1;
    public float falloffTime = 1f; //Time until the projectile disappears
    public float reloadSpeed = 1f;
    public int damage = 1;
}
