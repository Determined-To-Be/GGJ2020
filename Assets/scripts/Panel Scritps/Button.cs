using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : PanelObject
{
    
    private float pitchMod;
    public float pushDepth = -1;
    public Vector3 initPos;

    public void Start(){
        initPos = this.transform.localPosition;
        pitchMod = Random.Range(.5f, 1);
    }

    [SerializeField]
    UnityEvent  onDown = new UnityEvent(),
                onUp = new UnityEvent(),
                onHold = new UnityEvent();

    public override void OnHold(){
        onHold.Invoke();
    }

    public override void OnDown(){
        this.transform.localPosition = initPos + new Vector3(0, pushDepth, 0);
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_push"), 1, 1 * pitchMod);
        onDown.Invoke();
    }

    public override void OnUp(){
        this.transform.localPosition = initPos;
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_release"), 1, 1 * pitchMod);
        onUp.Invoke();
    }
}
