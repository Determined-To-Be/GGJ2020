using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {

    public bool jacobControl;

    LightColor lightColor;
    public Color color;

    [Range(0, 100)]
    public float flickerRate;
    [Range(0,100)]
    public float flickerBalance;
    [Range(0, 30)]
    public float flickerHardness;
    [Range(0, 100)]
    public float Minimum;
    public bool Consistent;
    public Light bulb;
    
    float time;
    float rng;
    float startBright;
    float BrightGoTo;

    private void Awake()
    {
        lightColor = GetComponent<LightColor>();

        if(jacobControl)
        {
            bulb = transform.GetChild(0).GetComponent<Light>();
            //color = transform.GetChild(0).GetComponent<Light>().color;
        }
    }

    private void Start()
    {
        startBright = bulb.intensity;
    }

    void Update ()
    {
        if (flickerRate != 0)
        time += Time.deltaTime;
        if (Consistent)
        {
            rng = Mathf.Sin(time*flickerRate) * 50 + 50;
            if (time >= (2*Mathf.PI)/flickerRate)
            {
                time = 0;
            }
        }
        else if (time > 1 / flickerRate)
        {
            time = 0;
            rng = Random.Range(0, 100);
        }

        if (rng > flickerBalance)
        {
            BrightGoTo = startBright*Minimum/100;
        }
        else
        {
            BrightGoTo = startBright;
        }

        bulb.intensity += (BrightGoTo - bulb.intensity) * Time.deltaTime * flickerHardness;

        if(jacobControl)
            lightColor.SetColor(new Color(color.r, color.g, color.b, bulb.intensity));
	}
}
