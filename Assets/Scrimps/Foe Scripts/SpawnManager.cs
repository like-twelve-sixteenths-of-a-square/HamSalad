using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foePrefabs;
    public int foeIndex;
    public int enemyCount;
    public int waveNumber = 1;
    public float spawnRange;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int foestoSpawn)
    {
        for (int i = 0; i < foestoSpawn; i++)
        {
            int foeIndex = Random.Range(0, foePrefabs.Length);
            Instantiate(foePrefabs[foeIndex], GenerateSpawnPosition(), transform.rotation);
        }
    }

    private Vector2 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        Vector2 randomPos = new Vector3(spawnPosX, 9, 0);
        return randomPos;
    }
}
