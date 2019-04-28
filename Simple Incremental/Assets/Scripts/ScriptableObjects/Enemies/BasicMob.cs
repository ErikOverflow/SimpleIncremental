using UnityEngine;

[CreateAssetMenu(menuName = "Templates/Enemies/Basic Mob")]
public class BasicMob : EnemyTemplate
{
    public int meleeDamage = 1;
    public float meleePunchForce = 200f;
    public AnimationClip animIdle = null;
    public AnimationClip animWalkLeft = null;
    public AnimationClip animWalkRight = null;
}