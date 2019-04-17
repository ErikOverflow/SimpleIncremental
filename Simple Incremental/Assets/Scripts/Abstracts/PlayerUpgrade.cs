using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUpgrade : ScriptableObject
{
    public Sprite sprite = null;
    public abstract void Augment(GameObject go);
}
