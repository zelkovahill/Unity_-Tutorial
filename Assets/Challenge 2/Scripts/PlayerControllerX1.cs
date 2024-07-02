using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX1 : MonoBehaviour
{
    public GameObject dogPrefab;
    private float Delay = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Delay -= Time.deltaTime;
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Delay <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
