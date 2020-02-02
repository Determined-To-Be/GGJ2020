using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dial : PanelObject
{
    public float angle = 0;
    public float speed = 1;
    public int ticks = 16;
    public bool useLimits = false;
    public float minAngle = 0, maxAngle = 0;

    AudioClip /*down, up,*/ move;
    public PanelEvent onDialChange = new PanelEvent();

    void Start()
    {
        // down = AudioManager.Instance.GetSample("player_button_push");
        // up = AudioManager.Instance.GetSample("player_button_release");
        move = AudioManager.Instance.GetSample("friendly_move");
    }

    float lastAngle = 0;
    public override void OnHold(){
        Vector3 rad = cam.WorldToScreenPoint(this.transform.position) - Input.mousePosition;

        float currAngle = ((Mathf.Atan2(rad.y, rad.x) * Mathf.Rad2Deg) + 180) * speed;

        angle += (currAngle - lastAngle);

        // if (Mathf.FloorToInt(angle) % (360 / ticks) == 0)
        //     AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, clickSound);

        if(useLimits){
            angle = Mathf.Clamp(angle, minAngle, maxAngle);
        }

        this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, angle, this.transform.localRotation.z); 
        lastAngle = currAngle;
        onDialChange.Invoke(angle);
    }

    public override void OnDown(){
        // AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, down);
        AudioManager.Instance.StartSound(AudioManager.Channel.friendly, move);
    }

    public override void OnUp(){
        // AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, up);
        AudioManager.Instance.StopSound(AudioManager.Channel.friendly);
    
    }

    //Source
    //https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain/1082938
    int mod(int x, int m) {
        int r = x%m;
        return r<0 ? r+m : r;
    }
}
