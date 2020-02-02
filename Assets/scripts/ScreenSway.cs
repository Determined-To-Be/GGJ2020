using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSway : MonoBehaviour
{
    [SerializeField] float intensityPos, intensityRot, speedPos, speedRot;

    Vector3 initPos;
    Quaternion initRot;
    float seed, seed2;

    void Awake()
    {
        
    }

    void Start()
    {
        initPos = this.transform.position;
        initRot = this.transform.rotation;
        seed = Random.seed;
        seed2 = seed++;
    }

    void Update()
    {
        float time = Time.time * speedPos;
        this.transform.position = initPos + new Vector3(Mathf.PerlinNoise(time, seed) * 2 - 1, Mathf.PerlinNoise(seed, time) * 2 - 1) * intensityPos;
        this.transform.rotation = Quaternion.Euler(initRot.eulerAngles.x, initRot.eulerAngles.y, (Mathf.PerlinNoise(Time.time * speedRot, seed2) * 2 - 1) * intensityRot);
    }
}
