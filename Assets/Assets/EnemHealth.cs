using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public 



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)Destroy(gameObject);
    }
}
