using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (!front_fire)
        {
            cameraY = cameraAgnle_Y + 180;
        }
        else
        {
            cameraY = (cameraAgnle_Y+360) ;
        }
       
        currentX = transform.rotation.eulerAngles.x;
        currentZ = transform.rotation.eulerAngles.z;
        Quaternion rotation = Quaternion.Euler(currentX, cameraY, currentZ);
        transform.rotation = rotation;
    }
}
