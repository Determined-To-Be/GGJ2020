using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{

    public Color color;
    Material mat;
    Light light;
    // Start is called before the first frame update
    void Awake()
    {
        light = this.GetComponentInChildren<Light>();
        mat = this.GetComponent<MeshRenderer>().material;
        light.color = color;
        mat.EnableKeyword("_EmissiveIntensity");
        mat.EnableKeyword("_EmissiveColor");

        mat.SetColor("_EmissiveColor", color); 
        mat.SetFloat("_EmissiveIntensity", color.a);
    }

    Color last = Color.white;
    // Update is called once per frame
    void Update()
    {   
        if(color == last)
            return;
        
        mat.SetColor("_EmissiveColor", color);
        mat.SetFloat("_EmissiveIntensity", color.a);
        light.color = color;
        light.intensity = color.a;
        
        
        last = color;
    }

    public void SetColor(Color color){
        this.color = color;
    }
}
