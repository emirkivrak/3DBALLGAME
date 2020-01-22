using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody EnemyRB;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookDirection = (Player.transform.position - transform.position).normalized;
        EnemyRB.AddForce( LookDirection * enemySpeed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
