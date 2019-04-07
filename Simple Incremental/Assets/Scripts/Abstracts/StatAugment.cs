using UnityEngine;

public abstract class StatAugment : MonoBehaviour
{
    public abstract void Augment();
    public abstract void Awake();
    public bool applied = true;
    public int priority = 1;
}