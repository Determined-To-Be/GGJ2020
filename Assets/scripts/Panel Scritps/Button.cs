using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : PanelObject
{
    
    private float pitchMod;

    public void Start(){
        pitchMod = Random.Range(.5f, 1);
    }

    [SerializeField]
    UnityEvent  onDown = new UnityEvent(),
                onUp = new UnityEvent(),
                onHold = new UnityEvent();

    public override void OnHold(){
        onHold.Invoke();

        print("On Hold");
    }

    public override void OnDown(){
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_push"), 1, 1 * pitchMod);
        onDown.Invoke();
        print("On Down");
    }

    public override void OnUp(){
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_release"), 1, 1 * pitchMod);
        onDown.Invoke();
        print("On Up");
    }
}
