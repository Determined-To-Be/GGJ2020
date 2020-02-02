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
    private int currWaypoint;
    private float dist;
    public float aggroRange;
    DroneSpawner ds;
    private void Start()
    {
        ds = FindObjectOfType<DroneSpawner>();
        nav.speed = speed;
        // setting speed of enemy
        nav = GetComponent<NavMeshAgent>();
        // accessing the nav mesh agent
        nav.SetDestination(waypoints[currWaypoint].position);
        // sets the destination of the nav mesh agent
        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        nav.destination = waypoints[currWaypoint].position;
        // setting the current destination as waypoint
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        // changes the current waypoint to the next waypoint
    }

    // Update is called once per frame
    void Update()
    {
        AggroCheck();

        if (aggro)
        {
            AggroBehav();
        }
        else
        {
            Patrol();
        }

    }

    void AggroCheck()
    {
        if (playerPos)
        {
            dist = Vector3.Distance(playerPos.position, transform.position);
            // finding position between player position and enemy position
            if (dist < aggroRange)
            {
                aggro = true;
            }
            else
                aggro = false;
        }
        else
        {
            if (!ds.isDead)
            {
                playerPos = FindObjectOfType<DroneMovement>().transform;
            }
        }
    }
    void AggroBehav()
    {
        if (playerPos)
        {
            nav.destination = playerPos.position;
            //if enemy knows where player already is
            //enemy will go to player's position   
        }

        else
        {
            aggro = false;
        }
    }
    void Patrol()
    {
        if (nav.remainingDistance < 0.5f)
        {
            GotoNextPoint();
            // if distance between player and enemey is small
            // enemy will continue to go back and forth between waypoints
        }
    }
}
