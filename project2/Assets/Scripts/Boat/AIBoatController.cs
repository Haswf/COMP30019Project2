﻿using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class AIBoatController : MonoBehaviour
{
    //Drags
    public Transform waterJetTransform;

    //How fast should the engine accelerate?
    public float powerFactor;

    //What's the boat's maximum engine power?
    public float maxPower;

    //The boat's current engine power is public for debugging
    public float currentJetPower;


    public Vector3 forceToAdd;
    public float waterJetRotationSpeed = 0.5f;

    private float currentSpeed;
    private Vector3 lastPosition;
    private float thrustFromWaterJet = 0f;

    private Rigidbody boatRB;

    public float WaterJetRotation_Y = 0f;

    AIBoatController aiboatController;
    AIController aIController;
    void Start()
    {
        boatRB = GetComponent<Rigidbody>();
        aiboatController = GetComponent<AIBoatController>();
        aIController = GetComponent<AIController>();
    }


    void Update()
    {
        UserInput();
        //        if (this.transform.eulerAngles.z < -5)
        //        {
        //            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -5);
        //        }
        //        else if (this.transform.eulerAngles.z > 5)
        //        {
        //            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 5);
        //        }
    }

    void UserInput()
    {
        //Forward / reverse
        if (aIController.GetInputMovement() == 'W')
        {
            if (aiboatController.CurrentSpeed < 50f && currentJetPower < maxPower)
            {
                currentJetPower += 1f * powerFactor;
            }
        }
        else if (aIController.GetInputMovement() == 'S')
        {
            if (aiboatController.CurrentSpeed < 50f && currentJetPower > -maxPower * 0.5)
            {
                currentJetPower -= 1f * powerFactor;
            }
        }

        //Steer left
        if (aIController.GetInputRotation() == 'D')
        {
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y + waterJetRotationSpeed;

            if (WaterJetRotation_Y > 10f && WaterJetRotation_Y < 290f)
            {
                WaterJetRotation_Y = 10f;
            }

            Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);
            waterJetTransform.localEulerAngles = newRotation;
        }

        //Steer right
        else if (aIController.GetInputRotation() == 'A')
        {
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y - waterJetRotationSpeed;

            if (WaterJetRotation_Y < 350f && WaterJetRotation_Y > 110f)
            {
                WaterJetRotation_Y = 350f;
            }

            Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);
            waterJetTransform.localEulerAngles = newRotation;
        }
    }

    void UpdateWaterJet()
    {
        //print(boatController.CurrentSpeed);

        forceToAdd = waterJetTransform.forward * currentJetPower;
        forceToAdd.y = 0;

        boatRB.AddForceAtPosition(forceToAdd, waterJetTransform.position);

    }

    void FixedUpdate()
    {
        UpdateWaterJet();
        CalculateSpeed();
        //Debug.Log(currentSpeed);
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
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
    public void SetWaterJetLocalRotationToZero()
    {
        waterJetTransform.localRotation = Quaternion.Euler(0,0,0);
    }
}