using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : PanelObject
{

    private float pitchMod;

    [SerializeField]
    UnityEvent  onToggleDown = new UnityEvent(),
                onToggleUp = new UnityEvent();

    bool state = false;

    public void Start(){
        pitchMod = Random.Range(.5f, 1);
    }

    public override void OnHold(){
    }

    public override void OnDown(){
        state = !state;
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_push"), 1, 1 * pitchMod);
        if(state){
            onToggleUp.Invoke();
        } else {
            onToggleDown.Invoke();
        }
    }

    public override void OnUp(){

    }
}
