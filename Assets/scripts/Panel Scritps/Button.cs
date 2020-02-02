using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : PanelObject
{
    
    public Vector3 motionDirection;

    private float pitchMod;
    public float pushDepth = -1;
    public Vector3 initPos;
    public float lerpStrength = 15;

    public void Start(){
        initPos = this.transform.localPosition;
        pitchMod = Random.Range(.5f, 1);
        goalPos = initPos;
    }

    Vector3 goalPos;
    void Update(){
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, goalPos, lerpStrength * Time.deltaTime);
    }

    [SerializeField]
    UnityEvent  onDown = new UnityEvent(),
                onUp = new UnityEvent(),
                onHold = new UnityEvent();

    public override void OnHold(){
        onHold.Invoke();
    }

    public override void OnDown(){
        goalPos = initPos + motionDirection * pushDepth;
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_push"), 1, 1 * pitchMod);
        onDown.Invoke();
    }

    public override void OnUp(){
        goalPos = initPos;
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_release"), 1, 1 * pitchMod);
        onUp.Invoke();
    }
}
