using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager4 : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    private void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
}
