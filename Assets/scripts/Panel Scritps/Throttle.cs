using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Throttle : PanelObject
{
    public float throttle;
    public float _throttle;
    public float maxDist = 1;
    public float lerpFactor = 15;
    public int ticks = 8;
    AudioClip down, up, move;

    public PanelEvent OnThrottleChange = new PanelEvent();

    public void Start(){
        down = AudioManager.Instance.GetSample("player_button_push");
        up = AudioManager.Instance.GetSample("player_button_release");
        move = AudioManager.Instance.GetSample("friendly_move");
    }

    public override void OnHold(){
        print((Input.mousePosition.y - initMousePos.y)/cam.pixelHeight);
        throttle += (Input.mousePosition.y - cam.WorldToScreenPoint(this.transform.position).y)/cam.pixelHeight;
        throttle = Mathf.Clamp(throttle, 0, 1); 
        _throttle = Mathf.Lerp(_throttle, throttle, Time.deltaTime * lerpFactor);

        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y,  Mathf.Clamp(-_throttle * maxDist, -maxDist, maxDist));
        OnThrottleChange.Invoke(_throttle);
    }

    Vector2 initMousePos;
    public override void OnDown(){
        initMousePos = Input.mousePosition;
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, down);
        AudioManager.Instance.StartSound(AudioManager.Channel.friendly, move);
    }

    IEnumerator returnCenter(){
        //TODO springback
        throttle = 0;
        while(Mathf.Abs(throttle - _throttle) > .01f){
            _throttle = Mathf.Lerp(_throttle, throttle, Time.deltaTime * lerpFactor);
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y,  -_throttle * maxDist);
            
            yield return null;
        }
        print("centered");
        yield return null;
    }

    public override void OnUp(){
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, up);
        AudioManager.Instance.StopSound(AudioManager.Channel.friendly);
        StartCoroutine(returnCenter());
    }

}
