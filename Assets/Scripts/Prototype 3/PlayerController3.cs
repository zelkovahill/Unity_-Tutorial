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

    private Animator playerAnim;
    
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
   
    

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }


    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.CompareTag("Ground"))
       {
           isOnGround = true;
           dirtParticle.Play();
       }
       else if(other.gameObject.CompareTag("Obstacle"))
       {
           explosionParticle.Play();
           gameOver = true;
           Debug.Log("Game Over!");
           playerAnim.SetBool("Death_b", true);
           playerAnim.SetInteger("DeathType_int", 1);
           dirtParticle.Stop();
           playerAudio.PlayOneShot(crashSound, 0.5f);
       }
    }
}
