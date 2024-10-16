using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriEnemySpawner : EnemySpawner
{
    [SerializeField] private TriEnemy triEnemyPrefab;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnCooldown)
        {
            Spawn(GetRandomSpawnPoint().position);
		}
    }

    public override void Spawn(Vector3 spawnPos)
    {
        TriEnemy instance = Instantiate(triEnemyPrefab, spawnPos, Quaternion.identity);
        instance.Initialize();
        spawnTimer = 0;
    }

    private Transform GetRandomSpawnPoint()
    {
        int idx = Random.Range(0, spawnPoints.Count);
        return spawnPoints[idx];
	}
}