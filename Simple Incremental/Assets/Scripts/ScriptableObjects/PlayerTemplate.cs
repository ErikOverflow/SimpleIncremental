using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerTemplate : ScriptableObject
{
    public string playerName = "Bob";
    public int health = 10;
    public float moveSpeed = 1f;
}
