using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : PanelObject
{

    private float pitchMod;

    public Vector3 rotationVector;
    public Vector2 rotationLimits;

    [SerializeField]
    UnityEvent  onToggleDown = new UnityEvent(),
                onToggleUp = new UnityEvent();

    public bool state = false;

    public void Start(){
        pitchMod = Random.Range(.5f, 1);
    }

    public override void OnHold(){
    }

    public override void OnDown(){
        state = !state;
        if(state){
            print(new Vector3(rotationVector.x * rotationLimits.x, rotationVector.y * rotationLimits.x, rotationVector.z * rotationLimits.x));
            this.transform.localRotation = Quaternion.Euler(rotationVector.x * rotationLimits.x, rotationVector.y * rotationLimits.x, rotationVector.z * rotationLimits.x);
            onToggleUp.Invoke();
        } else {
            print(new Vector3(rotationVector.x * rotationLimits.y, rotationVector.y * rotationLimits.y, rotationVector.z * rotationLimits.y));
            this.transform.localRotation = Quaternion.Euler(rotationVector.x * rotationLimits.y, rotationVector.y * rotationLimits.y, rotationVector.z * rotationLimits.y);
            onToggleDown.Invoke();
        }
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_push"), 1, 1 * pitchMod);
    }

    public override void OnUp(){

    }
}
