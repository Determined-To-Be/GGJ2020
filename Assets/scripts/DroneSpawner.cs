using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject thePrefab;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && isDead)
        {
            isDead = false;
            Instantiate(thePrefab, transform.position, Quaternion.identity);
        }
         
    }
}
