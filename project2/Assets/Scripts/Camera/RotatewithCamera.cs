using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotatewithCamera : MonoBehaviour
{
    public bool front_fire;
    public Camera camera;
    private float cameraY;
    private float currentX;
    private float currentZ;
    private float maxAngle = 140;
    private float minAngle = -140;

    private float rote;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        // the angle which camera rotates
        float cameraAgnle_Y = camera.transform.rotation.eulerAngles.y;
        currentX = transform.parent.rotation.eulerAngles.x;
        currentZ = transform.parent.rotation.eulerAngles.z;
        if (!front_fire)
        {    
            // for the fire on the back pont
            cameraY = cameraAgnle_Y + 180;
            //give range to avoid penetration model
            Quaternion rotation = Quaternion.Euler(currentX - 90, RangeOfAngle(cameraY, minAngle, maxAngle), currentZ);

                transform.rotation = rotation;
            
        }
        else
        {     
            // for the fire on the front pont
            cameraY = (cameraAgnle_Y);
            //give range to avoid penetration model
            Quaternion rotation = Quaternion.Euler(currentX - 90,  RangeOfAngle(cameraY, minAngle, maxAngle), currentZ);
            transform.rotation = rotation;

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
