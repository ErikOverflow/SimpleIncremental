using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileTemplate : ScriptableObject
{
    public Sprite sprite = null;
    public float speed = 1f;
    public int maxPenetrations = 1;
    public float damageModifier = 1f; //Percent of attack that this projectile deals
    public float falloffTime = 1f; //Time until the projectile disappears
}
