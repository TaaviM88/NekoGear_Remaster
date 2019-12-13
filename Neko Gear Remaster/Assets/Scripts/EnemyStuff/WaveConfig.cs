using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    public GameObject enemyPrefab;
    public float timeBetweenSpawns = 0.5f;
    public float spawnRandomFactor = 0.3f;
    public int numberOfEnemies = 10;
    public float moveSpeed;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public float GEtTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
