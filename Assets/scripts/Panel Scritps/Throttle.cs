using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Throttle : PanelObject
{
    public float throttle;
    float _throttle;
    public float maxDist = 1;
    public float verticalScreenHeight = .15f;
    public float lerpFactor = 15;
    Vector3 center;

    UnityEvent OnThrottleChange = new UnityEvent();

    Camera cam;

    public void Start(){
        center = this.transform.position;
        cam = Camera.main;
    }

    public override void OnHold(){
        
        throttle = (Input.mousePosition.y - initMousePos.y)/cam.scaledPixelHeight / verticalScreenHeight;
        throttle = Mathf.Clamp(throttle, -1, 1); 
        _throttle = Mathf.Lerp(_throttle, throttle, Time.deltaTime * lerpFactor);

        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y,  Mathf.Clamp(-_throttle * maxDist, -maxDist, maxDist));

    }

    Vector2 initMousePos;
    public override void OnDown(){
        initMousePos = Input.mousePosition;
    }

    IEnumerator springBack(){
        yield return null;
    }

    public override void OnUp(){
    }

}
