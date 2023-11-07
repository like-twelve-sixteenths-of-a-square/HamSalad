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

    public GameObject powerupPrefab;
    public int goodie;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        int powerupChance = Random.Range(1, 6);
        if (powerupChance == 1)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        goodie = GameObject.FindGameObjectsWithTag("Swagger").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
        int powerupChance = Random.Range(1, 6);
        if (powerupChance == 1 && goodie == 0)
        {
            Instantiate(powerupPrefab, GeneratePowerupPosition(), transform.rotation);
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

    private Vector2 GeneratePowerupPosition()
    {
        float spawnPosX = Random.Range(-spawnRange+2, spawnRange-2);
        Vector2 randomPos = new Vector3(spawnPosX, -5, 0);
        return randomPos;
    }
}
