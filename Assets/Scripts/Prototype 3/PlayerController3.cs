using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    
    public bool isOnGround = true;
    public bool gameOver = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.CompareTag("Ground"))
       {
           isOnGround = true;
       }
       else if(other.gameObject.CompareTag("Obstacle"))
       {
           gameOver = true;
           Debug.Log("Game Over!");
       }
    }
}
