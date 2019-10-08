using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]

public class Buoyancy : MonoBehaviour
{
    public float waterLevel = 0.0f;

    public float buoyancyThreshold = 2.00f;

    public float waterDensity = 0.125f;

    public float downForce = 4.0f;

    private float forceFactor;

    private Vector3 force;
    // Calculate buoyancy in fixed update
    public Rigidbody boatRigidBody;
    
    void Start()
    {
        boatRigidBody = GetComponent<Rigidbody>();
    }
    
    
    void FixedUpdate()
    {
        forceFactor = 1.0f - (transform.position.y - waterLevel) / buoyancyThreshold;
        if (forceFactor > 0.0f)
        {
            float mass = boatRigidBody.mass;
            force = (forceFactor - boatRigidBody.velocity.y * waterDensity) * mass * -Physics.gravity;
            force += new Vector3(0.0f, -downForce * mass, 0.0f);
            boatRigidBody.AddForceAtPosition(force, transform.position);
        }
        
    }
}
