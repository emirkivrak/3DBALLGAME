using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, Mathf.PingPong(Time.time,3));
        transform.RotateAround(Vector3.up, Time.deltaTime * 2);
    }
}
