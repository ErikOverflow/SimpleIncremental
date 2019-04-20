using DragonBones;
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
    UnityEngine.Transform throwingHand = null;
    private int layerNum;
    string attackName = "Fork throw";
    UnityArmatureComponent armatureComponent;
    Camera mainCam;

    public void Awake()
    {
        mainCam = Camera.main;
        layerNum = Mathf.RoundToInt(Mathf.Log(layer.value, 2));
        armatureComponent = GetComponent<UnityArmatureComponent>();
        armatureComponent.animation.animationConfig.additiveBlending = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            armatureComponent.animation.FadeIn(attackName, -1, 1, 2, "Blend");
            //armatureComponent.animation.PlayConfig(new AnimationConfig { animation = attackName, additiveBlending = true, layer = 1 });
            LaunchProjectile();
        }
    }
    public void LaunchProjectile()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - transform.position;
        GameObject go = ObjectPooler.instance.GetPooledObject(projectilePrefab);
        go.transform.parent = ObjectPooler.instance.transform;
        go.transform.position = throwingHand.position;
        go.transform.localScale = Vector3.one;
        go.transform.rotation = throwingHand.rotation;
        Projectile p = go.GetComponent<Projectile>();
        p.gameObject.layer = layerNum;
        p.Launch(dir, projectileSprite, damage, falloffTime, maxHits, projectileLaunchForce, projectileTorque);
    }
}
