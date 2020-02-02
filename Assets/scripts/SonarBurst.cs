using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarBurst : MonoBehaviour
{
    public ParticleSystem ps;
    public Transform arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            triggerBurst();
        }
    }
    public void triggerBurst()
    {
        ps.Emit(1);
        arrow.LookAt(GameObject.FindGameObjectWithTag("part").transform);
    }
}
