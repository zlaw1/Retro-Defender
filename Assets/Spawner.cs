using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject healthPot;
    public GameObject enemy;

    public Transform[] enemySpawns;
    public Transform[] healthSpawns;
    private Transform pick1;
    private Transform pick2;
    private int randomNum1;
    private int randomNum2;

    public float enemyTimer = 5f;
    public float healthTimer = 10f;
    
    // Start is called before the first frame update
    // Update is called once per frame
 
    void Update()
    {
        
        if(enemyTimer <= 0 )
        {
            randomNum1 = Random.Range(0, enemySpawns.Length);
            
            Instantiate(enemy, enemySpawns[randomNum1].position, enemySpawns[randomNum1].rotation);
            enemyTimer = 5f;
        }
        enemyTimer -= Time.deltaTime;
        if(healthTimer <= 0)
        {
            randomNum2 = Random.Range(0, healthSpawns.Length);
            
            Instantiate(healthPot, healthSpawns[randomNum2].position, healthSpawns[randomNum2].rotation);
            healthTimer = 10f;
        }
        healthTimer -= Time.deltaTime;
    }
}
