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
        this.transform.tag = "MainCamera";
    }

    PanelObject po;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ 
            po = FindPanelObject();
            
            if(po != null)
                po.OnDown();
        }

        if(Input.GetMouseButton(0)){ 
            if(po != null)
                po.OnHold();
        }

        if(Input.GetMouseButtonUp(0)){ 
            if(po != null){
                po.OnUp();
                po = null;
            }
                
        }
    }

    PanelObject FindPanelObject(){
        RaycastHit hit;

        Debug.DrawRay(this.transform.position, cam.ScreenPointToRay(Input.mousePosition).direction, Color.green, 10);
        if(Physics.Raycast(this.transform.position, cam.ScreenPointToRay(Input.mousePosition).direction, out hit, 100)){
            if(hit.transform.tag == "Interactable"){
                print("found " + hit + "!");
                Debug.DrawLine(this.transform.position, hit.point);
                //If Interactable assume it is a Panel Object
                return hit.transform.gameObject.GetComponent<PanelObject>();
            }
        }
        print("nothing found");
        return null;
    }
}
