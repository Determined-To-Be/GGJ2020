using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ 
            PanelObject po = FindPanelObject();
            if(po != null)
                po.OnDown();
        }

        if(Input.GetMouseButtonUp(0)){ 
            PanelObject po = FindPanelObject();
            if(po != null)
                po.OnUp();
        }
    }

    PanelObject FindPanelObject(){
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position, cam.ScreenToWorldPoint(Input.mousePosition), out hit)){
            if(hit.transform.tag == "Interactable"){
                //If Interactable assume it is a Panel Object
                return hit.transform.gameObject.GetComponent<PanelObject>();
            }
        }
        return null;
    }
}
