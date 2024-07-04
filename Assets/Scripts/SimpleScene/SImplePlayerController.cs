using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SImplePlayerController : MonoBehaviour
{
  private float speed = 10.0f;
  private Rigidbody playerRb;
  private float zBound = 6.0f;
  
  

  private void Start()
  {
    playerRb = GetComponent<Rigidbody>();
  }

  private void Update()
  {
    MovePlayer();
    Backups();
  }

  private void MovePlayer()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    
    playerRb.AddForce(Vector3.forward * speed * verticalInput);
    playerRb.AddForce(Vector3.right * speed * horizontalInput);
  }

  private void Backups()
  {
    if (transform.position.z < -zBound)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
    }
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Enemy"))
    {
      Debug.Log("Game Over!");
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Powerup"))
    {
      Destroy(other.gameObject);
    }
  }
}
