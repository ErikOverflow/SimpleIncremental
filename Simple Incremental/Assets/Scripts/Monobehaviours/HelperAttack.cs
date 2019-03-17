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
        StartCoroutine(StartAttackCycle());
    }

    private void OnEnable()
    {
        freeToAttack = true;
    }

    private IEnumerator StartAttackCycle()
    {
        while (!freeToAttack)
        {
            yield return null;
        }
        target = EnemyManager.instance.enemies.FirstOrDefault();
        while (target != null)
        {
            freeToAttack = false;
            target.TakeDamage(attackStat.GetCalculatedDamage());
            yield return new WaitForSeconds(cooldown);
        }
        freeToAttack = true;
    }

    public void UntargetEnemy(GameObject go)
    {
        if(go.GetComponent<CharacterHealth>() == target)
        {
            target = null;
            StartCoroutine(StartAttackCycle());
        }
    }

    public void OnEnemySpawn()
    {
        if(target == null)
        {
            StartCoroutine(StartAttackCycle());
        }
    }
}
