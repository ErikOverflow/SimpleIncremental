using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyTargeting))]
public class HelperAttackEnemy : MonoBehaviour
{
    bool freeToAttack = true;
    PlayerTarget target;
    EnemyTargeting enemyTargetingRef;

    private void Awake()
    {
        enemyTargetingRef = GetComponent<EnemyTargeting>();
    }

    private void Update()
    {
        if (freeToAttack)
        {
            StartCoroutine(StartAttackCycle());
        }
    }

    private void OnEnable()
    {
        freeToAttack = true;
    }

    private IEnumerator StartAttackCycle()
    {
        target = enemyTargetingRef.FindATarget();

        while (!freeToAttack || !target.gameObjectRef.activeSelf)
        {
            yield return null;
        }
        
        while (target.gameObjectRef.activeSelf)
        {
            freeToAttack = false;
            target.gameObjectRef.GetComponent<CharacterHealth>().TakeDamage(AttackStatEnemy.
                GetCalculatedDamage(target.enemyAttack.minDamage, target.enemyAttack.maxDamage));

            yield return new WaitForSeconds(target.enemyAttack.attackCooldown);
        }
        freeToAttack = true;
    }

    // Need to restart coRoutine if more player gameobject spawn in
}
