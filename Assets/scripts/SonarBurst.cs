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
        sp = arrow.gameObject.GetComponentInChildren<SpriteRenderer>();
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
        ps.Emit(3);
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 1);
        arrow.LookAt(part.transform);
        Vector3 arrowDir = part.transform.position-transform.position;
        arrow.position = transform.position+arrowDir.normalized*arrowDist ;
        arrow.LookAt(part.transform);
        StopAllCoroutines();
        StartCoroutine(fade());
    }
    private IEnumerator fade()
    {
        while (sp.color.a > 0)
        {
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, Mathf.Clamp01(sp.color.a-0.05f));
            yield return new WaitForSeconds(1f / 20f);
        }
    }

}
