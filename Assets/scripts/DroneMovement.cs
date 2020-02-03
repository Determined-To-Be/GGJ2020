using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public float throttle;
    public Vector2 rotationInput;
    Rigidbody2D rb;
    public bool testMovement;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float maxAcceleration;
    [SerializeField]
    float maxAngularSpeed;
    [SerializeField]
    float maxAngularAcceleration;
    [SerializeField]
    float drag;
    Vector2 velocity;
    Vector2 angularVelocity;
    bool boostMode = false;
    public float boostAccelAngle;
    public float boostSpeed;
    public float boostAccel;
    public SpriteRenderer boostRenderer;
    public SpriteRenderer invisBody;
    public bool isCooldown = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {


        if (testMovement)
            TestDroneInput();
        Vector3 desiredVelocity;
        if (!boostMode)
             desiredVelocity = throttle*transform.up * maxSpeed;
        else
            desiredVelocity = (throttle+boostSpeed) * transform.up * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        
            velocity.x =
                Mathf.MoveTowards(rb.velocity.x, desiredVelocity.x, boostMode ? boostAccel*Time.deltaTime : maxSpeedChange);
            velocity.y =
                Mathf.MoveTowards(rb.velocity.y, desiredVelocity.y, boostMode ? boostAccel*Time.deltaTime : maxSpeedChange);
        
        if (0 == throttle&&!boostMode)
            velocity *= drag;
        
        rb.velocity = velocity;
        if(!boostMode)
            angularVelocity= Vector3.RotateTowards(angularVelocity, rotationInput, maxAngularAcceleration, 1);
        else
            angularVelocity = Vector3.RotateTowards(angularVelocity, rotationInput, boostAccelAngle, 1);
        transform.up = angularVelocity;
    }

    public void setAngle(float angle){
        Vector2 dir =  (Vector2)(Quaternion.Euler(0,0,angle + 90) * Vector2.right);
        rotationInput = dir;
    }

    public void setThrottle(float throttle){
        this.throttle = throttle;
    }


    void TestDroneInput()
    {
        throttle =  Input.GetAxisRaw("Vertical");
        rotationInput = Vector3.RotateTowards(transform.up, Input.GetAxisRaw("Horizontal")*transform.right, 0.1f, 0);
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleBoostMode();
        }
        if (Input.GetKeyDown(KeyCode.I) && isCooldown)
        {
            isCooldown = false;
            StopAllCoroutines();
            StartCoroutine(PlayerCountdown());
        }
    }
    public void ToggleBoostMode()
    {
        boostMode = !boostMode;
        boostRenderer.enabled = boostMode;
    }

    public void SetRotationInput(Vector2 newRot)
    {
        rotationInput = newRot;
    }

    public void EnterInvis(){
        if(!isCooldown)
            return;
        isCooldown = false;
        StopAllCoroutines();
        StartCoroutine(PlayerCountdown());
    }
    public void InvisbleMode()
    {
        
        invisBody.enabled = !invisBody.enabled;
        // will make invisBody the opposite of what is was
      
        
    }
    IEnumerator PlayerCountdown()
    {
        InvisbleMode();
        yield return new WaitForSeconds(4);
        InvisbleMode();
        yield return new WaitForSeconds(4);
        isCooldown = true;
    }
}