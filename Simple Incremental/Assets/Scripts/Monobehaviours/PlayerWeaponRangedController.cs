using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponRangedController : MonoBehaviour
{
    public Sprite projectileSprite = null;
    public int damage = 0;
    public float falloffTime = 1f;
    public int maxHits = 1;
    public float projectileLaunchForce = 100f;
    public float projectileTorque = 5;

    [SerializeField]
    GameObject projectilePrefab = null;
    [SerializeField]
    LayerMask layer;
    [SerializeField]
    Transform throwingHand = null;
    private int layerNum;
    private Animator anim;
    int attackRangedHash = Animator.StringToHash("AttackRanged");
    Camera mainCam;

    public void Awake()
    {
        mainCam = Camera.main;
        layerNum = Mathf.RoundToInt(Mathf.Log(layer.value, 2));
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            anim.SetTrigger(attackRangedHash);
        }
    }
    public void LaunchProjectile()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - transform.position;
        GameObject go = ObjectPooler.instance.GetPooledObject(projectilePrefab);
        go.transform.parent = ObjectPooler.instance.transform;
        go.transform.position = throwingHand.position;
        go.transform.localScale = transform.localScale;
        go.transform.rotation = throwingHand.rotation;
        Projectile p = go.GetComponent<Projectile>();
        p.gameObject.layer = layerNum;
        p.Launch(dir, projectileSprite, damage, falloffTime, maxHits, projectileLaunchForce, projectileTorque);
    }
}
