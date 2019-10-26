using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class BoatController : MonoBehaviour
{    
    //The boat's current engine power is public for debugging
    public float currentJetPower;

    //Drags    
    private Transform waterJetTransform;
    //How fast should the engine accelerate?
    private float powerFactor = Settings.PlayerPowerFactor;
    //What's the boat's maximum engine power?
    private float maxPower = Settings.PlayerMaxPower;
    private float _maxSpeed = Settings.PlayerMaxSpeed;
    private Vector3 forceToAdd;
    private float waterJetRotationSpeed = 0.5f;
    private float currentSpeed;
    private Vector3 lastPosition;
    private float thrustFromWaterJet = 0f;
    private Rigidbody boatRB;
    private float WaterJetRotation_Y;
    private HealthManager healthManager;

    void Start()
    {
        boatRB = GetComponent<Rigidbody>();
        waterJetTransform = transform.Find("WaterJet").gameObject.transform;
        healthManager = GetComponent<HealthManager>();
    }


    void Update()
    {
        UserInput();
    }


    void UserInput()
    {
        //Forward / reverse
        if (Input.GetKey(KeyCode.W))
        {
            if (currentJetPower < maxPower)
            {
                currentJetPower += 1f * powerFactor;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (currentJetPower > -maxPower * 0.5)
            {
                currentJetPower -= 1f * powerFactor;
            }
        }

        //Steer left
        if (Input.GetKey(KeyCode.A))
        {     
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y + waterJetRotationSpeed;

            if (WaterJetRotation_Y > 10f && WaterJetRotation_Y < 290f)
            {
                WaterJetRotation_Y = 10f;
            }

            
            Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);
            waterJetTransform.localEulerAngles = newRotation;
            
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            WaterJetRotation_Y = 0;
        }
        

        //Steer right
        if (Input.GetKey(KeyCode.D))
        {    
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y - waterJetRotationSpeed;

            if (WaterJetRotation_Y < 350f && WaterJetRotation_Y > 110f)
            {
                WaterJetRotation_Y = 350f;
            }


            Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);
            waterJetTransform.localEulerAngles = newRotation;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            WaterJetRotation_Y = 0;
        }
    }

    void UpdateWaterJet()
    {
        //print(boatController.CurrentSpeed);

        forceToAdd = waterJetTransform.forward * currentJetPower;
        forceToAdd.y = 0;
        boatRB.AddForceAtPosition(forceToAdd, waterJetTransform.position, ForceMode.Impulse);

    }

    void FixedUpdate()
    {
        if (healthManager.getIsAlive())
        {
            if (boatRB.velocity.magnitude < Settings.EnemyMaxSpeed)
            {
                UpdateWaterJet();
            }
        }
        else
        {
             GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    //Calculate the current speed in m/s
    private void CalculateSpeed()
    {
        //Calculate the distance of the Transform Object between the fixedupdate calls with 
        //'(transform.position - lastPosition).magnitude' Now you know the 'meter per fixedupdate'
        //Divide this value by Time.deltaTime to get meter per second
        currentSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;

        //Save the position for the next update
        lastPosition = transform.position;
    }
	
    public float CurrentSpeed
    {
        get
        {
            if (currentJetPower > 0)
            {
                return currentSpeed;
            }
            else
            {
                return -currentSpeed;
            }

        }
    }
    
}