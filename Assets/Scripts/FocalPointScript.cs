using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPointScript : MonoBehaviour
{
    public float RotationSpeed = 1.0f;
    void Start()
    {
        
    }

   
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * RotationSpeed * HorizontalInput * Time.deltaTime);

        
    }
}
