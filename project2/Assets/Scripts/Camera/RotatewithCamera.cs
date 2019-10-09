using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RotatewithCamera : MonoBehaviour
{
    public Camera camera;
    public Base[] barrels;
    private float maxAngle = 140;
    private float minAngle = -140;
    private float maxAngleFront = 320;
    private float minAngleFront = 40;

    private float rote;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        for (int i=0; i < barrels.Length; i++)
        {
            barrels[i].barrel.transform.rotation = CalculateRotation(
                new Vector3(
                    transform.rotation.eulerAngles.x, 
                    camera.transform.rotation.eulerAngles.y,
                    transform.rotation.eulerAngles.z), 
                barrels[i].isFront);
        }
    }

    private Quaternion CalculateRotation(Vector3 rotation, bool isFront) {
        if (!isFront)
        {
            // for the fire on the back pont
            //give range to avoid penetration model
            return Quaternion.Euler(rotation.x - 90, Mathf.Clamp(rotation.y, minAngleFront, maxAngleFront), rotation.z);
        }
        else
        {
            // for the fire on the front pont
            //give range to avoid penetration model
            return Quaternion.Euler(rotation.x - 90, RangeOfAngle(rotation.y, minAngle, maxAngle), rotation.z);
        }

    }

    float RangeOfAngle(float angle, float minRange, float maxRange) {
        
        //for the angle which is greater than 180 degrees or smaller than negative 180 degrees
        if (angle > 180) {
            angle -= 360;
        } else if (angle < -180) {
            angle += 360;
        }
        
        //for the minimum range of angle which is greater than 180 degrees or smaller than negative 180 degrees
        if (minRange > 180) {
            minRange -= 360;
        } else if (minRange < -180) {
            minRange += 360;
        }
        
        //for the maximum range of angle which is greater than 180 degrees or smaller than negative 180 degrees
        if (maxRange > 180) {
            maxRange -= 360;
        } else if (maxRange < -180) {
            maxRange += 360;
        }
 
        // Aim is, convert angles to -180 until 180.
        return Mathf.Clamp(angle, minRange, maxRange);
    }
}

[System.Serializable]
public struct Base
{
    public string name;
    public GameObject barrel;
    public bool isFront;
}
