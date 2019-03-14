using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EnemyHook))]
public class EnemyScaling : MonoBehaviour
{
    public int level = 1;

    float ramp = 1f;
    int gate = 1;
    float gateJump = 1f;

    EnemyHook enemyHook = null;

    public void SetScale(float _amount, float _ramp, int _gate)
    {
        gateJump = _amount;
        ramp = _ramp;
        gate = _gate;
    }

    private void Awake()
    {
        enemyHook = GetComponent<EnemyHook>();
    }

    private void OnEnable()
    {
        ScaleToLevel();
    }

    public void ScaleToLevel()
    {
        float multiplier = Mathf.Pow(gateJump, level / gate) * (1f + (level % gate) * ramp);
        enemyHook.ScaleEnemy(multiplier);
    }

    private void OnValidate() //Enables use in editor
    {
        if (SceneManager.GetActiveScene().isLoaded)
        {
            Awake();
            ScaleToLevel();
        }
    }
}
