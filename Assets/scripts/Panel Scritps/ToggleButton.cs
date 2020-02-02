using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : PanelObject
{

    private float pitchMod;

    public Vector3 rotationVector;
    public Vector2 rotationLimits;
    public float lerpStrength = 15;

    [SerializeField]
    UnityEvent  onToggleDown = new UnityEvent(),
                onToggleUp = new UnityEvent();

    public bool state = false;

    public void Start(){
        pitchMod = Random.Range(.5f, 1);
        goalRot = Quaternion.Euler(rotationVector.x * rotationLimits.x, rotationVector.y * rotationLimits.x, rotationVector.z * rotationLimits.x);
    }
    
    Quaternion goalRot;
    void Update(){
        this.transform.localRotation = Quaternion.Slerp(this.transform.localRotation, goalRot, lerpStrength * Time.deltaTime);
    }

    public override void OnHold(){
    }

    public override void OnDown(){
        state = !state;
        if(state){
            goalRot = Quaternion.Euler(rotationVector.x * rotationLimits.x, rotationVector.y * rotationLimits.x, rotationVector.z * rotationLimits.x);
            onToggleUp.Invoke();
        } else {
            goalRot = Quaternion.Euler(rotationVector.x * rotationLimits.y, rotationVector.y * rotationLimits.y, rotationVector.z * rotationLimits.y);
            onToggleDown.Invoke();
        }
        AudioManager.Instance.PlaySoundOnce(AudioManager.Channel.player, AudioManager.Instance.GetSample("player_button_push"), 1, 1 * pitchMod);
    }

    public override void OnUp(){

    }
}
