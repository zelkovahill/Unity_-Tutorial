using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleSpawnManager : MonoBehaviour
{
   public GameObject[] enemies;
   public GameObject powerup;

   private float zEnemySpawn = 12.0f;
   private float xSpawnRange = 16.0f;
   private float zPowerupSpawn = 5.0f;
   private float ySpawn = 0.75f;

   private float powerupSpawnTime = 5.0f;
   private float enemySpawnTime = 1.0f;
   private float startDelay = 1.0f;

   private void Start()
   {
      InvokeRepeating(nameof(SpawnEnemy),startDelay,enemySpawnTime);
      InvokeRepeating(nameof(SpawnPowerup),startDelay,powerupSpawnTime);
   }

   private void SpawnEnemy()
   {
      float randomX = Random.Range(-xSpawnRange, xSpawnRange);
      int randomIndex = Random.Range(0, enemies.Length);
      
      Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);
      
      Instantiate(enemies[randomIndex],spawnPos,enemies[randomIndex].transform.rotation);
   }

   private void SpawnPowerup()
   {
      float randomX = Random.Range(-xSpawnRange, xSpawnRange);
      float randomZ = Random.Range(0, zPowerupSpawn);
      
      Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);
      
      Instantiate(powerup,spawnPos,powerup.transform.rotation);
   }
}
