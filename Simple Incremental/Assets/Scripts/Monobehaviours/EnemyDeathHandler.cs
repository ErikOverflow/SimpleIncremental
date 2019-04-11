using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    CharacterHealth ch = null;
    Animator anim;
    [SerializeField]
    int deathHash = Animator.StringToHash("Death");

    private void Awake()
    {
        ch = GetComponent<CharacterHealth>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ch.OnDeath += EnemyDied;
    }

    private void EnemyDied()
    {
        gameObject.SetActive(false);
    }
}
