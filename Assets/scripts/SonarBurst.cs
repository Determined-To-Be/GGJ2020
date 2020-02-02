using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarBurst : MonoBehaviour
{
    public ParticleSystem ps;
    public Transform arrow;
    public float arrowDist;
    SpriteRenderer sp;
    GameObject part;
    // Start is called before the first frame update
    void Start()
    {
        sp = arrow.gameObject.GetComponent<SpriteRenderer>();
        part = GameObject.FindGameObjectWithTag("part");
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
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 1);
        arrow.LookAt(part.transform);
        Vector3 arrowDir = transform.position - part.transform.position;
        arrow.position = arrowDir.normalized * arrowDist;
        arrow.LookAt(part.transform);
    }
}
