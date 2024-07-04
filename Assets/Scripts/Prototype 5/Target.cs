using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
   private Rigidbody targetRb;

   private float minSpeed = 12;
   private float maxSpeed = 16;
   private float maxTorque = 10;
   private float xRange = 4;
   private float ySpawnPos = -6;
   private void Start()
   {
      targetRb = GetComponent<Rigidbody>();
      targetRb.AddForce(RandomForce(), ForceMode.Impulse);
      targetRb.AddTorque(RandomToque(), RandomToque(), RandomToque(), ForceMode.Impulse);
      transform.position = RandomSpawnPos();
   }

   private Vector3 RandomForce()
   {
      return Vector3.up * Random.Range(minSpeed, maxSpeed);
   }

   private float RandomToque()
   {
      return Random.Range(-maxTorque, maxTorque);
   }

   private Vector3 RandomSpawnPos()
   {
      return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
   }

   private void OnMouseDown()
   {
      Destroy(gameObject);
   }

   private void OnTriggerEnter(Collider other)
   {
      Destroy(gameObject);
   }
}
