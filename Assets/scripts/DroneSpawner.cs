using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DroneSpawner : MonoBehaviour
{

    public Dial dial;
    public Throttle throttle; 
    public ToggleButton door, boost;
    public Button selfDestruct;


    public GameObject thePrefab;
    public bool isDead = false;
   
    public void SpawnDrone(){
        if(!isDead)
            return;

        isDead = false; 
        var player = FindObjectOfType<CameraFollow>().target = Instantiate(thePrefab, transform.position, Quaternion.identity).transform;

        dial.onDialChange.AddListener(player.GetComponent<DroneMovement>().setAngle);
        throttle.OnThrottleChange.AddListener(player.GetComponent<DroneMovement>().setThrottle);
        boost.onToggleDown.AddListener(player.GetComponent<DroneMovement>().ToggleBoostMode);
        boost.onToggleUp.AddListener(player.GetComponent<DroneMovement>().ToggleBoostMode);
        selfDestruct.onDown.AddListener(player.GetComponent<SelfDestruct>().InitiateSD);;
    }
}
