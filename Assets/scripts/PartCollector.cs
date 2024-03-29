﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
    public static int partsCollected = 0;
    public GameObject partSprite;
    public GameObject partPrefab;
    public bool carryPart = false;
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
        if (!carryPart&&other.CompareTag("part"))
        {
            partSprite.active = true;
            Destroy(other.gameObject);
            carryPart = true;
        }
        if (other.CompareTag("home"))
        {
            partSprite.active = false;
            partsCollected++;
            carryPart = false;
            //transition to next level
        }
    }
    private void OnDestroy()
    {

        if (carryPart)
        {
            Instantiate(partPrefab,partSprite.transform.position,Quaternion.identity);
        }
    }
}
