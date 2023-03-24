using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveController : MonoBehaviour
{
    public int enemyType;

    public Enemy[] enemy;

    private int active;

    private void Update()
    {
        StartCoroutine(CheckEnemiesCount());
    }

    IEnumerator CheckEnemiesCount()
    {
        yield return new WaitForSeconds(5f);

        foreach (var enemyForeach in enemy)
        {
            if (enemyForeach.gameObject.activeInHierarchy)
            {
                active++;
                break;
            }
        }

        if (active <= 0)
        {
            ObjectPool.Instance.BackToPoolObject(gameObject, enemyType);
        }

        active = 0;
    }
}
