using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public float knockbackMult;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("damage"))
        {
            health--;
            if (health == 0)
            {
                GetComponent<SelfDestruct>().InitiateSD();
            }
            GetComponent<Rigidbody2D>().AddForce(collision.GetContact(0).normal*knockbackMult);
        }
    }
}
