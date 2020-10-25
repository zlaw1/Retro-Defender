using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.name == "character") other.GetComponent<PlayHealth>().RestoreHealth(); 
        Destroy(gameObject);
    }
}
