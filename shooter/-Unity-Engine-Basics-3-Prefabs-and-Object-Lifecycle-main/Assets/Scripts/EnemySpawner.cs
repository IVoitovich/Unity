using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Player _player;
    [SerializeField] private float _spawnPeriod;

    private float _time;
        
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > _spawnPeriod)
        {
            SpawnEnemy();
            _time = 0;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = GetRandomSpawnPoint();
        Vector3 lookDirection = 
            _player.transform.position - (Vector3)spawnPosition;

        Instantiate(
            _enemyPrefab,
            spawnPosition,
            Quaternion.LookRotation(Vector3.forward, lookDirection)
        );
    }

    private Vector2 GetRandomSpawnPoint()
    {
        float xValue = 0;
        while (xValue < 8 && xValue > -8)
            xValue = Random.Range(-15f, 15f);
        
        float yValue = 0;
        while (yValue < 5 && yValue > -5)
            yValue = Random.Range(-10f, 10f);

        return new Vector2(xValue, yValue);
    }
}
