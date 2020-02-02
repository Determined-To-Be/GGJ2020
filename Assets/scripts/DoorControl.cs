using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    Animator anim;
    public bool testing;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)&&testing)
        {
            toggleDoor();
        }
    }
    public void toggleDoor()
    {
        anim.SetBool("closed", !anim.GetBool("closed"));
    }
}
