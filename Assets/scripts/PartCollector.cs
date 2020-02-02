using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
    public bool partsCollected;
    public GameObject partSprite;
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
        print(collision.collider.name);
        if ((!partsCollected) && collision.collider.CompareTag("part"))
        {
            partSprite.active = true;
            Destroy(collision.collider.gameObject);
            partsCollected = true;
        }
        if (collision.collider.CompareTag("home"))
        {
            partSprite.active = false;
            partsCollected = false;
            //transition to n
        }
    }
        private void OnTriggerEnter(Collider other)
    {
        if (!partsCollected&&other.CompareTag("part"))
        {
            partSprite.active = true;
            Destroy(other.gameObject);
            partsCollected = true;
        }
        if (other.CompareTag("home"))
        {
            partSprite.active = false;
            partsCollected = false;
            //transition to next level
        }
    }
}
