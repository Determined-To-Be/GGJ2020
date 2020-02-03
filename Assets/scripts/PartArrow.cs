using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartArrow : MonoBehaviour
{
    public Transform arrow;
    public SpriteRenderer sp;
    public Transform player;
    public float maxRange;
    public DroneSpawner ds;
    bool fading;
    public float blinkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ds = FindObjectOfType<DroneSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        updateArrowPos();
        updateArrowColor();
    }
    void updateArrowColor()
    {
        if (sp.color.a == 1)
            fading = true;
        else if (sp.color.a == 0)
            fading = false;
        if (fading)
        {
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, Mathf.Clamp01(sp.color.a - blinkSpeed));
        }
        else
        {
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, Mathf.Clamp01(sp.color.a + blinkSpeed));
        }
    }
    void updateArrowPos() { 
    
        if (player)
        {
            var dir = (transform.position - player.position).normalized;
            var dist = Mathf.Clamp(Vector3.Distance(player.position, transform.position)/2, 0, maxRange);
            arrow.position = player.position + dir * dist;
            arrow.LookAt(player);
        }
        else
        {
            if(!ds.isDead)
                player = FindObjectOfType<DroneMovement>().transform;
        }
    }
}
