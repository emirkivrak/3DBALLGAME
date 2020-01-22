using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{   public float spawnRange = 9.0f;
    public GameObject Enemy;
    public int count_enemy;
    private int wave_number = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(1);
    }

    // Update is called once per frame
    void Update()
    {
        count_enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        if(count_enemy == 0)
        {
            wave_number += 1;
            SpawnWave(wave_number);
        }

    }

    private Vector3 RandomSpawnPosition()
    {
         float SpawnX = Random.Range(-spawnRange, spawnRange);
        float SpawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 position = new Vector3(SpawnX, 0, SpawnZ);
        return position;
    }
    private void SpawnWave(int enemycount)
    {
        for(int i = 0; i < enemycount; i++)
        {
            Instantiate(Enemy, RandomSpawnPosition(), Enemy.transform.rotation);
        }
    }
    
}
