using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    PirateController[] controllers;
    void Start()
    {
        controllers = GameObject.FindObjectsOfType<PirateController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void invis(){
        foreach(PirateController pi in controllers){
            pi.Invisib();
        }
    }
}
