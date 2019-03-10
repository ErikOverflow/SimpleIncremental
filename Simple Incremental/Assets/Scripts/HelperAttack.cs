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

    private void Awake()
    {
        attackStat = GetComponent<AttackStat>();
    }

    private void Start()
    {
        StartCoroutine(StartAttackCycle());
    }

    private IEnumerator StartAttackCycle()
    {
        target = EnemyManager.instance.enemies.FirstOrDefault();
        while (target != null)
        {
            target.TakeDamage(attackStat.GetCalculatedDamage());
            yield return new WaitForSeconds(cooldown);
        }
    }

    private IEnumerator DelayedStartAttackCycle()
    {
        yield return null;
        StartCoroutine(StartAttackCycle());
    }

    public void Retarget()
    {
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
