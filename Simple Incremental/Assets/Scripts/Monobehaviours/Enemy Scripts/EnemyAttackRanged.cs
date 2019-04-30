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

    Transform projectileContainer = null;
    [SerializeField]
    GameObject projectilePrefab = null;
    [SerializeField]
    LayerMask layer;
    private int layerNum;

    private void Start()
    {
        layerNum = Mathf.RoundToInt(Mathf.Log(layer.value, 2));
        projectileContainer = ObjectPooler.instance.transform;
    }


    public void ShootProjectile(Transform target)
    {
        GameObject go = ObjectPooler.instance.GetPooledObject(projectilePrefab);
        Projectile p = go.GetComponent<Projectile>();
        go.transform.position = transform.position;
        go.transform.rotation = Quaternion.identity;
        go.transform.parent = projectileContainer;
        p.gameObject.layer = layerNum;
        p.Launch(target.position - transform.position, projectileSprite, damage, falloffTime, maxPenetrations, projectileSpeed, projectileRotation);
    }
}
