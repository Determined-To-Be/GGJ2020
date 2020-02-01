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
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {


        if (testMovement)
            TestDroneInput();
        
        Vector3 desiredVelocity = throttle*transform.up * maxSpeed;

        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x =
            Mathf.MoveTowards(rb.velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y =
            Mathf.MoveTowards(rb.velocity.y, desiredVelocity.y, maxSpeedChange);
        if (0 == throttle)
            velocity *= drag;
        rb.velocity = velocity;
        angularVelocity= Vector3.RotateTowards(angularVelocity, rotationInput, maxAngularAcceleration, 1);
        transform.up = angularVelocity;
    }
    void TestDroneInput()
    {
        throttle =  Input.GetAxisRaw("Vertical");
        rotationInput = Vector3.RotateTowards(transform.up, Input.GetAxisRaw("Horizontal")*transform.right, 0.1f, 0);
    }
    public void SetRotationInput(Vector2 newRot)
    {
        rotationInput = newRot;
    }
}