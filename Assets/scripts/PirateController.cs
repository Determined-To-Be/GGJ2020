using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateController : MonoBehaviour
{ 
    public float speed;
    public NavMeshAgent nav;
    public Transform playerPos;

    private void Start()
    {
        nav.speed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = playerPos.position;
    }


}
