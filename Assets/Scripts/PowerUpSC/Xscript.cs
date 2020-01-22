using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.up, 5 * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 1), transform.position.z);
    }
}
