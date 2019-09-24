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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cameraAgnle_Y = camera.transform.rotation.eulerAngles.y;
        currentX = transform.rotation.eulerAngles.x;
        currentZ = transform.rotation.eulerAngles.z;
        if (!front_fire)
        {
            cameraY = cameraAgnle_Y + 180;
            Quaternion rotation = Quaternion.Euler(currentX, cameraY, currentZ);

                transform.rotation = rotation;
            
        }
        else
        {
            cameraY = (cameraAgnle_Y+360) ;
            Quaternion rotation = Quaternion.Euler(currentX, cameraY, currentZ);
            transform.rotation = rotation;
        }

        
    }
}
