using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondEffect : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.RotateAround(Vector3.up, 90.0f );
    }
}
