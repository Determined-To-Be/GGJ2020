using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelObject : MonoBehaviour
{

    public bool holding = false;
    
    public void Update(){
        if(holding)
            OnHold();
    }

    public virtual void OnHold(){
        
    }

    public virtual void OnDown(){
        holding = true;
    }

    public virtual void OnUp(){
        holding = false;
    }
}
