using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public int enemyCount;
    public float spawnRange;

    public GameObject powerupPrefab;
    public int goodie;

    private void Start()
    {
        int powerupChance = Random.Range(1, 6);
        if (powerupChance == 1)
        {
            Instantiate(powerupPrefab, GeneratePowerupPosition(), transform.rotation);
        }
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        goodie = GameObject.FindGameObjectsWithTag("Swagger").Length;
        if (enemyCount == 0)
        {
            SpawnPowerup();
        }
    }

    void SpawnPowerup()
    {
        int powerupChance = Random.Range(1, 6);
        if (powerupChance == 1 && goodie == 0)
        {
            Instantiate(powerupPrefab, GeneratePowerupPosition(), transform.rotation);
        }
    }

    private Vector2 GeneratePowerupPosition()
    {
        float powerPosX = Random.Range(-spawnRange + 2, spawnRange - 2);
        Vector2 lootPos = new Vector3(powerPosX, -5.5f, 0);
        return lootPos;
    }
}
