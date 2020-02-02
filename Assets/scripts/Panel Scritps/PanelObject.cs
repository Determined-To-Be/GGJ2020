using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PanelObject : MonoBehaviour
{
    protected static Camera cam;
    public void Awake(){
        this.transform.tag = "Interactable";
        cam = Camera.main;
    }

    public abstract void OnHold();

    public abstract void OnDown();

    public abstract void OnUp();
}
