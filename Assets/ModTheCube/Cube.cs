using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float timer = 1;
    private Material material;
    
    void Start()
    {
        // transform.position = new Vector3(3, 4, 1);  // 위치 변경    
        // transform.localScale = Vector3.one * 1.3f;          // 크기 변경
        
        material = Renderer.material;  
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f); // 색상 변경
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        
        float RandomX = Random.Range(-10, 10);
        
        if (timer <= 0)
        {
            material.color = new Color(RandomX, RandomX, RandomX, RandomX); // 색상 변경
        }
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);   // 회전
    }
    
    
}
