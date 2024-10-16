using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public abstract void Spawn(Vector3 spawnPos);
}
