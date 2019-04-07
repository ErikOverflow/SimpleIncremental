using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackHandler : MonoBehaviour
{
    public event Action PlayerAttackRanged;

    public void AttackRanged()
    {
        PlayerAttackRanged?.Invoke(); 
    }

}
