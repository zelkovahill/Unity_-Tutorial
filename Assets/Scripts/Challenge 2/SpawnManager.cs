using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
   public GameObject[] animalPrefabs;
   private float spawnRangeX = 20;
   private float spawnPosZ = 20;
   
   private float startDelay = 2;
   private float spawnInterval = 1.5f;


   private void Start()
   {
      InvokeRepeating(nameof(SpawnRandomAnimal),startDelay,spawnInterval);
   }

   private void Update()
   {
     
   }

   private void SpawnRandomAnimal()
   {
      int animalIndex = Random.Range(0, animalPrefabs.Length);
      Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spawnPosZ);
      Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
   }
}
