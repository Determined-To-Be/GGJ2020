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

        Debug.DrawRay(this.transform.position, cam.ScreenPointToRay(Input.mousePosition).direction, Color.green, 10);
        if(Physics.Raycast(this.transform.position, cam.ScreenPointToRay(Input.mousePosition).direction, out hit, 100)){
            if(hit.transform.tag == "Interactable"){
                Debug.DrawLine(this.transform.position, hit.point);
                //If Interactable assume it is a Panel Object
                return hit.transform.gameObject.GetComponent<PanelObject>();
            }
        }

        return null;
    }
}
