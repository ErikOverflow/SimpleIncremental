using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErikOverflow.FiniteStateMachine;

public class EnemyStateData : CharStateData
{
    [System.NonSerialized] public Rigidbody2D rb2d;
    [System.NonSerialized] public CharacterHealth characterHealth;
    [System.NonSerialized] public Transform currentTarget = null;
    [System.NonSerialized] public float moveSpeed;
    public Collider2D scanningCollider;
    [SerializeField]
    LayerMask mask = new LayerMask();
    [System.NonSerialized] public ContactFilter2D cf2d;
    [System.NonSerialized] public Animator anim;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        characterHealth = GetComponent<CharacterHealth>();
        cf2d = new ContactFilter2D();
        cf2d.layerMask = mask;
        cf2d.useLayerMask = true;
        anim = GetComponent<Animator>();
    }
}
