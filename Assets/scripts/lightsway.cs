using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsway : MonoBehaviour
{
    public float amp;
    public float speed;

    public float Hamp;
    Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = start + new Vector3(Mathf.Sin(Time.time * speed) * amp, Mathf.Cos(Time.time*speed*2)*Hamp, 0);
    }
}
