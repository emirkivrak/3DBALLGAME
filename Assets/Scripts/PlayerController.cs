using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] Effects;
    private Rigidbody Rigid;
    private GameObject focalPoint;
    private GameObject PowerUps;
    private GameObject powerUpEnemy;
    private int powerupcode;
    private SpawnManagerScript spawnManagerScript;
    public float ForwardSpeed = 10.0f;  
    public bool onPowerUp = false;
    public bool onEffect = false;
    private float VerticalInput;
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
    }


    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        Rigid.AddForce(focalPoint.transform.forward * ForwardSpeed * VerticalInput);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PowerUpGem") // 5 saniyeligine güclü hale geliyor
        {
            onPowerUp = true;
            powerUpEffectMaker(0, 5);
            powerupcode = 0;
            SphereCollider colliderr = GetComponent<SphereCollider>();
            colliderr.radius = 0.8f;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpTimer()); // powerup yazısı eklenecek
        }

        if(other.gameObject.name == "ExecuteUp") // rastgele bir dusmanı ucurur
        {
            onPowerUp = true;   
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            Rigidbody enemyRigid = enemy.gameObject.GetComponent<Rigidbody>();
            Vector3 PowerShot = enemy.gameObject.transform.position - transform.position;
            enemyRigid.AddForce(PowerShot * 30, ForceMode.Impulse); // powerup yazısı eklenecek
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && onPowerUp == true && powerupcode == 0)
        {
               
            Rigidbody enemyRigid = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 PowerShot = collision.gameObject.transform.position - transform.position;
            enemyRigid.AddForce(PowerShot * 10, ForceMode.Impulse); 
            Debug.Log("collided with enemy on powerup"); 
        }
    }
    
    private IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(5);
        onPowerUp = false;
       
        SphereCollider colliderr = GetComponent<SphereCollider>();
        colliderr.radius = 0.5f;
    }
    
    private void powerUpEffectMaker(int power_up_index , int time) {
        onEffect = true;
        Instantiate(Effects[0], transform.position, Effects[0].transform.rotation);
        StartCoroutine(EffectTimer(5));
    }

    private IEnumerator EffectTimer(int time) {
        yield return new WaitForSeconds(time);
        onEffect = false;
        GameObject powerUp = GameObject.FindGameObjectWithTag("Effect");
        Destroy(powerUp);

        
    }
}
