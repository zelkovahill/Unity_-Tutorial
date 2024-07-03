using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    
    private float startDelay = 2;
    private float repeatRate = 2;
    
    private PlayerController3 playerControllerScript;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle),startDelay,repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
    }
    
    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
             Instantiate(obstaclePrefab,spawnPos, obstaclePrefab.transform.rotation);
        }
       
    }
    
    
}
