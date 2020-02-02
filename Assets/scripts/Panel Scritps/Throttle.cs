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
    public int ticks = 8;
    Vector3 center;
    AudioClip down, up;

    UnityEvent OnThrottleChange = new UnityEvent();

    public void Start(){
        center = this.transform.position;
        down = AudioManager.Instance.GetSample("player_button_push");
        up = AudioManager.Instance.GetSample("player_button_release");
    }

    public override void OnHold(){
        
        throttle = (Input.mousePosition.y - initMousePos.y)/cam.scaledPixelHeight / verticalScreenHeight;
        throttle = Mathf.Clamp(throttle, -1, 1); 
        _throttle = Mathf.Lerp(_throttle, throttle, Time.deltaTime * lerpFactor);

        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y,  Mathf.Clamp(-_throttle * maxDist, -maxDist, maxDist));
        OnThrottleChange.Invoke();
    }

    Vector2 initMousePos;
    public override void OnDown(){
        initMousePos = Input.mousePosition;
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, down);
    }

    IEnumerator springBack(){
        yield return null;
    }

    public override void OnUp(){
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, up);
    }

}
