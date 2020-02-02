using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelfDestruct : MonoBehaviour
{
    public float radius;
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            InitiateSD();
        }

    }
    public void InitiateSD()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        //foreach (NavMeshAgent a in FindObjectsOfType<NavMeshAgent>())
        //{
        //    if (Vector3.Distance(transform.position, a.transform.position) < radius)
        //    {
                
        //        Destroy(a.gameObject);
        //    }
        //}
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        FindObjectOfType<DroneSpawner>().isDead = true;
    }
}
