using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{

    public Color color;
    Material mat;
    Light light;
    Coroutine flash;

    float speed = 1f;

    public Color active, inactive;
    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponentInChildren<Light>();
        mat = this.GetComponent<MeshRenderer>().material;
        light.color = color;
        mat.EnableKeyword("_EmissiveIntensity");
        mat.EnableKeyword("_EmissiveColor");

        mat.SetColor("Color_3641C126", color); 
        mat.SetFloat("Vector1_A5D7DE2A", color.a * 50);
    }

    Color last = Color.clear;
    // Update is called once per frame
    void Update()
    {   
       
        mat.SetColor("Color_3641C126", color);
        mat.SetFloat("Vector1_A5D7DE2A", color.a * 50);
        light.color = color;
        light.intensity = color.a;
        
        
        last = color;
    }

    public void activate(){
        this.color = active;
    }

    public void FlashStart()
    {
        flash = StartCoroutine(Flashing());
    }

    public void FlashStop()
    {
        deactivate();
        StopCoroutine(flash);
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            float ratio = 0f;
            while (this.color != active)
            {
                ratio += Time.deltaTime * speed;
                if (ratio > 1f) ratio = 1f;
                this.color = Color.Lerp(inactive, active, ratio);
                yield return null;
            }
            ratio = 0f;
            while (this.color != inactive)
            {
                ratio += Time.deltaTime * speed;
                if (ratio > 1f) ratio = 1f;
                this.color = Color.Lerp(active, inactive, ratio);
                yield return null;
            }
            yield return null;
        }
    }

    public void deactivate(){
        this.color = inactive;
    }

    public void SetColor(Color color){
        this.color = color;
    }
}
