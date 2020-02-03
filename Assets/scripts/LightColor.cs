using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{

    public Color color;
    Material mat;
    Light light;

    public Color active, inactive;
    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponentInChildren<Light>();
        mat = this.GetComponent<MeshRenderer>().material;
        light.color = color;
        mat.EnableKeyword("_EmissiveIntensity");
        mat.EnableKeyword("_EmissiveColor");

        mat.SetColor("_EmissiveColor", color); 
        mat.SetFloat("_EmissiveIntensity", color.a);
    }

    Color last = Color.clear;
    // Update is called once per frame
    void Update()
    {   
       
        mat.SetColor("_EmissiveColor", color);
        mat.SetFloat("_EmissiveIntensity", color.a);
        light.color = color;
        light.intensity = color.a;
        
        
        last = color;
    }

    public void activate(){
        this.color = active;
    }


    public void deactivate(){
        this.color = inactive;
    }

    public void SetColor(Color color){
        this.color = color;
    }
}
