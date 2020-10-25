using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdown : MonoBehaviour
{
    private float count = 5f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(count <= 0) gameObject.SetActive(false);
        count -= Time.deltaTime;
    }
}
