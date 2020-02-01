using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : PanelObject
{
    
    private float pitchMod = Random.Range(.5f, 1);

    [SerializeField]
    UnityEvent  onDown = new UnityEvent(),
                onUp = new UnityEvent(),
                onHold = new UnityEvent();

    public override void OnHold(){
        onHold.Invoke();
    }

    public override void OnDown(){
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_push"), 1, 1 * pitchMod);
        onDown.Invoke();
    }

    public override void OnUp(){
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_release"), 1, 1 * pitchMod);
        onDown.Invoke();
    }
}
