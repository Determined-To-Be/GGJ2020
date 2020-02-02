using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSway : MonoBehaviour
{
    #pragma warning disable 0649
    [SerializeField] float intensityPos, intensityRot, speedPos, speedRot;
    #pragma warning restore 0649

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
        seed = Random.Range(int.MinValue, int.MaxValue);
        seed2 = seed >= int.MaxValue ? int.MinValue : seed++;
    }

    void Update()
    {
        float time = Time.time * speedPos;
        this.transform.position = initPos + new Vector3(Mathf.PerlinNoise(time, seed) * 2 - 1, Mathf.PerlinNoise(seed, time) * 2 - 1) * intensityPos;
        this.transform.rotation = Quaternion.Euler(initRot.eulerAngles.x, initRot.eulerAngles.y, (Mathf.PerlinNoise(Time.time * speedRot, seed2) * 2 - 1) * intensityRot);
    }
}
