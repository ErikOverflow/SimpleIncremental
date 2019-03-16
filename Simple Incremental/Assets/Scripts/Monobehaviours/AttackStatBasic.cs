using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatBasic : AttackStat
{
    public int damage;

    public override int GetCalculatedDamage()
    {
        return damage;
    }
}
