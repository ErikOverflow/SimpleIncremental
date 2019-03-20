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

    [SerializeField]
    GameObject projectilePrefab = null;
    [SerializeField]
    LayerMask layer;
    private int layerNum;
    EnemyTargeting targeting = null;
    bool attacking = false;
    bool continueAttacking = false;

    Queue<Projectile> projectiles = null;

    private void Awake()
    {
        targeting = GetComponent<EnemyTargeting>();
    }

    private void Start()
    {
        projectiles = ProjectileManager.instance.projectiles;
        layerNum = Mathf.RoundToInt(Mathf.Log(layer.value, 2));
        targeting.OnNewTargetAcquired += StartFiring;
        targeting.OnTargetLost += StopFiring;
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
            ShootProjectile();
            yield return new WaitForSeconds(reloadTime);
        }
        attacking = false;
    }

    public void ShootProjectile()
    {
        Projectile p = null;
        if (projectiles.Count > 0)
        {
            p = projectiles.Dequeue();
            p.transform.position = transform.position;
            p.transform.rotation = transform.rotation;
        }
        else
        {
            GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity, ProjectileManager.instance.transform);
            p = go.GetComponent<Projectile>();
        }
        p.gameObject.layer = layerNum;
        p.Launch(targeting.target.position - transform.position, projectileSprite, damage, falloffTime, maxPenetrations, projectileSpeed);
    }
}
