using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   private float speed = 30;
   private float leftBound = -15;
   private PlayerController3 playerControllerScript;

   private void Start()
   {
      playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
   }

   private void Update()
   {
      if (playerControllerScript.gameOver == false)
      {
         transform.Translate(Vector3.left * Time.deltaTime * speed);
      }
      
      if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
      {
         Destroy(gameObject);
      }
      
   }
}
