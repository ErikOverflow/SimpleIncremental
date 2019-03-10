using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AttackStat))]
public class HelperAttack : MonoBehaviour
{
    AttackStat attackStat = null;
    float cooldown = 1.0f;
    CharacterHealth target = null;
    bool freeToAttack = true;

    private void Awake()
    {
        attackStat = GetComponent<AttackStat>();
    }

    private void Start()
    {
        Retarget();
    }

    private IEnumerator StartAttackCycle()
    {
        while (target != null)
        {
            freeToAttack = false;
            target.TakeDamage(attackStat.GetCalculatedDamage());
            yield return new WaitForSeconds(cooldown);
        }
        freeToAttack = true;
    }

    private IEnumerator DelayedStartAttackCycle()
    {
        yield return null;
        while (!freeToAttack)
        {
            yield return null;
        }
        Retarget();
    }

    public void Retarget()
    {
        target = EnemyManager.instance.enemies.FirstOrDefault();
        StartCoroutine(StartAttackCycle());
    }

    public void OnEnemyDeath(GameObject go)
    {
        if(go.GetComponent<CharacterHealth>() == target)
        {
            target = null;
            StartCoroutine(DelayedStartAttackCycle());
        }
    }

    public void OnEnemySpawn()
    {
        if(target == null)
        {
            Retarget();
        }
    }
}
