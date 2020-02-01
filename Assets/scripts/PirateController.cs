using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateController : MonoBehaviour
{ 
    public float speed;
    public NavMeshAgent nav;
    public Transform playerPos;
    public bool aggro = true;
    public Transform[] waypoints;

    private void Start()
    {
        nav.speed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aggro)
        {
            nav.destination = playerPos.position;
            // if enemy knows where player already is
        }
        else
        {
            nav.destination = waypoints[0].position;
        }

    }
}
