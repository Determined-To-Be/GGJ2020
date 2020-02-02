using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
    public bool partsCollected;
    public GameObject partSprite;
    public GameObject partPrefab;
      // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.name);
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
    private void OnDestroy()
    {

        if (partsCollected)
        {
            Instantiate(partPrefab,partSprite.transform.position,Quaternion.identity);
        }
    }
}
