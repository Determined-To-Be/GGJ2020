using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateController : MonoBehaviour
{ 
    public float speed;
    public NavMeshAgent nav;
   



    private void Start()
    {
        nav.speed = speed;
        //nav.destination = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
