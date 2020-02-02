using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dial : PanelObject
{
    float currAngle = 0;
    public int ticks = 16;
    public bool useLimits = false;
    public float minAngle = 0, maxAngle = 0;

    public override void OnHold(){
        //Store the initial position of the mouse
        //Calculate the difference between the current and new position
        //Using the difference calculate the angle to add to the dial
        //Rince and repeat
    }

    public override void OnDown(){
    }

    public override void OnUp(){
    }

}
