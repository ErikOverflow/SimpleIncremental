using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleIncremental.Weapon
{
    public class ProjectileWeapon : Weapon
    {
        [SerializeField]
        GameObject projectilePrefab = null;

        public SpriteRenderer spriteRenderer = null;
        public Sprite projectileSprite = null;
        public float projectileSpeed = 1f;
        public int maxPenetrations = 1;
        public float falloffTime = 1f;

        [SerializeField]
        LayerMask layer;
        private int layerNum;

        public void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            layerNum = Mathf.RoundToInt(Mathf.Log(layer.value, 2));
        }

        public override void Attack(Vector2 target)
        {
            GameObject go = ObjectPooler.instance.GetPooledObject(projectilePrefab);
            Projectile p = go.GetComponent<Projectile>();
            go.transform.position = transform.position;
            go.transform.rotation = Quaternion.identity;
            go.transform.parent = transform;
            p.gameObject.layer = layerNum;
            p.Launch(target - (Vector2)transform.position, projectileSprite, damage, falloffTime, maxPenetrations, projectileSpeed);
        }
    }
}