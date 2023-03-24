using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public Transform spawnerTransforms;

    public List<EnemyWaveController> enemies = new List<EnemyWaveController>();

    public float waveDelay;

    private float _timer;

    private void Awake()
    {
        _timer = waveDelay;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        
        if (_timer <= 0)
        {
            if (enemies.Count > 0)
            {
                ObjectPool.Instance.GetPooledObject(enemies[0].enemyType, transform, transform.eulerAngles);

                enemies.RemoveAt(0);

                _timer = waveDelay;
            }

            else
            {
                Debug.Log("Wave finished");
            }
        }
    }
}
