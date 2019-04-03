using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTargeting))]
public class EnemyAttackRanged : MonoBehaviour
{

    public Sprite projectileSprite = null;
    public int damage = 1;
    public float falloffTime = 1f;
    public int maxPenetrations = 1;
    public float projectileSpeed = 1f;
    public float reloadTime = 1f;
    Animator anim;

    Transform projectileContainer = null;
    [SerializeField]
    GameObject projectilePrefab = null;
    [SerializeField]
    LayerMask layer;
    private int layerNum;
    EnemyTargeting targeting = null;
    bool attacking = false;
    bool continueAttacking = false;

    private void OnDisable()
    {
        attacking = false;
    }

    private void Awake()
    {
        targeting = GetComponent<EnemyTargeting>();
    }

    private void Start()
    {
        layerNum = Mathf.RoundToInt(Mathf.Log(layer.value, 2));
        targeting.OnNewTargetAcquired += StartFiring;
        targeting.OnTargetLost += StopFiring;
        projectileContainer = ObjectPooler.instance.transform;
        anim = gameObject.GetComponent<Animator>();
    }

    private void StartFiring()
    {
        if (!attacking)
            StartCoroutine(Attack());
    }

    private void StopFiring()
    {
        continueAttacking = false;
    }

    private IEnumerator Attack()
    {
        attacking = true;
        continueAttacking = true;
        while (continueAttacking)
        {
            anim.SetTrigger("AttackRanged");
            ShootProjectile();
            yield return new WaitForSeconds(reloadTime);
        }
        attacking = false;
    }

    public void ShootProjectile()
    {
        GameObject go = ObjectPooler.instance.GetPooledObject(projectilePrefab);
        Projectile p = go.GetComponent<Projectile>();
        go.transform.position = transform.position;
        go.transform.rotation = Quaternion.identity;
        go.transform.parent = projectileContainer;
        p.gameObject.layer = layerNum;
        p.Launch(targeting.target.position - transform.position, projectileSprite, damage, falloffTime, maxPenetrations, projectileSpeed);
    }
}
