using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5f;
    
    private float zDestroy = -10;
    private Rigidbody objectRb;

    private void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
}