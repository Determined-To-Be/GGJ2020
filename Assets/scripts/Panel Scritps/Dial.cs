using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dial : PanelObject
{
    public float angle = 0;
    public int ticks = 16;
    public bool useLimits = false;
    public float minAngle = 0, maxAngle = 0;

    float lastAngle = 0;
    public override void OnHold(){
        Vector3 rad = cam.WorldToScreenPoint(this.transform.position) - Input.mousePosition;

        float currAngle = ((Mathf.Atan2(rad.y, rad.x) * Mathf.Rad2Deg) + 180);

        angle += currAngle - lastAngle;

        if(useLimits){
            angle = Mathf.Clamp(angle, minAngle, maxAngle);
        }

        this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, angle, this.transform.localRotation.z); 
        lastAngle = currAngle;
    }

    public override void OnDown(){
    }

    public override void OnUp(){
    
    }

    void OnDrawGizmos(){
    }

}
