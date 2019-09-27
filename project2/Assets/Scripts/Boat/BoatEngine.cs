using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class BoatEngine : MonoBehaviour 
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
    
    
    private float thrustFromWaterJet = 0f;

    private Rigidbody boatRB;

    public float WaterJetRotation_Y = 0f;

    BoatController boatController;

    void Start() 
	{
        boatRB = GetComponent<Rigidbody>();

        boatController = GetComponent<BoatController>();
    }


    void Update() 
	{
        UserInput();
    }

    void FixedUpdate()
    {
        UpdateWaterJet();
    }

    void UserInput()
    {
        //Forward / reverse
        if (Input.GetKey(KeyCode.W))
        {
            if (boatController.CurrentSpeed < 50f && currentJetPower < maxPower)
            {
                currentJetPower += 1f * powerFactor;
            }
        }
        else if (Input.GetKey(KeyCode.S)) {
            if (boatController.CurrentSpeed < 50f && currentJetPower > -maxPower * 0.5)
            {
                currentJetPower -= 1f * powerFactor;
            }
        }

        //Steer left
        if (Input.GetKey(KeyCode.A))
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
        else if (Input.GetKey(KeyCode.D))
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
        print(boatController.CurrentSpeed);

        forceToAdd = waterJetTransform.forward * currentJetPower;


        //Only add the force if the engine is below sea level
        float waveYPos = WaterController.current.GetWaveYPos(waterJetTransform.position, Time.time);

        if (waterJetTransform.position.y < waveYPos)
        {
            boatRB.AddForceAtPosition(forceToAdd, waterJetTransform.position);
        }
        else
        {
            boatRB.AddForceAtPosition(Vector3.zero, waterJetTransform.position);
        }
    }
}	