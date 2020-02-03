using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // Start is called before the first frame update
    DoorControl[] controllers;

    void Start()
    {
        controllers = GameObject.FindObjectsOfType<DoorControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleDoors(){
        foreach(DoorControl door in controllers){
            door.toggleDoor();
        }
    }
}
