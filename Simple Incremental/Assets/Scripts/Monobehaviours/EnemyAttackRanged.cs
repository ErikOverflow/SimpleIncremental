using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRanged : MonoBehaviour
{
    public Sprite projectileSprite = null;
    public int damage = 1;
    public float falloffTime = 1f;
    public int maxPenetrations = 1;
    public float projectileSpeed = 1f;
    public float reloadTime = 1f;
    public float projectileRotation = 20;
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
        targeting = GetComponentInParent<EnemyTargeting>();
    }

    private void Start()
    {
        layerNum = Mathf.RoundToInt(Mathf.Log(layer.value, 2));
        projectileContainer = ObjectPooler.instance.transform;
        anim = GetComponentInParent<Animator>();
    }

    public void StartFiring()
    {
        if (!attacking)
            StartCoroutine(Attack());
    }

    public void StopFiring()
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
            yield return new WaitForSeconds(reloadTime);
        }
        attacking = false;
    }

    public void ShootProjectile()
    {
        GameObject go = ObjectPooler.instance.GetPooledObject(projectilePrefab);
        Projectile p = go.GetComponent<Projectile>();
        Transform target = targeting.target;
        if (target == null)
            return;
        go.transform.position = transform.position;
        go.transform.rotation = Quaternion.identity;
        go.transform.parent = projectileContainer;
        p.gameObject.layer = layerNum;
        p.Launch(target.position - transform.position, projectileSprite, damage, falloffTime, maxPenetrations, projectileSpeed, projectileRotation);
    }
}
