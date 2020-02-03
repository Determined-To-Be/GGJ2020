using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LightColor : MonoBehaviour
{

    public Color color;
    Material mat;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponentInChildren<Light>();
        mat = this.GetComponent<Material>();
        light.color = color;
        mat.SetColor("_EmissionColor", color); 
    }

    Color last = Color.white;
    // Update is called once per frame
    void Update()
    {   
        if(color == last)
            return;

        light.color = color;
        mat.SetColor("_EmissionColor", color);
        last = color;
    }

    public void SetColor(Color color){
        this.color = color;
    }
}
