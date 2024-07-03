using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX3 : MonoBehaviour
{
    public bool gameOver;
    private bool isLowEnough = true;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private float topBound = 15.0f;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        //playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough) 
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        
        if(topBound < transform.position.y)
        {
            isLowEnough = false;
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
        else
        {
            isLowEnough = true;
        }
        
        
        
        // if(topBound < transform.position.y)
        // {
        //     transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
        //     playerRb.velocity = Vector3.zero;
        // }
        //
        // if(transform.position.y < 0 && !gameOver)
        // {
        //     playerAudio.PlayOneShot(bounceSound, 1.0f);
        //     transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //     playerRb.velocity = Vector3.zero;
        // }
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
        
        else if(other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

    }

}
