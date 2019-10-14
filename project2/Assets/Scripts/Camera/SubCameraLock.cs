using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SubCameraLock : MonoBehaviour
{

    float mouseX, mouseY;


    private const float Y_ANGLE_MAX = 0.0f;
    private const float Y_ANGLE_MIN = -60.0f;
    private const float X_ROTATION_MIN = 50.0f;
    private const float X_ROTATION_MAX = 79.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
       // mouseY = Mathf.Clamp(mouseY, Y_ANGLE_MIN, Y_ANGLE_MAX);
       
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, X_ROTATION_MIN, X_ROTATION_MAX);
        //transform.localRotation = Quaternion.Euler(currentRotation.x, 0, 0);

    }
}
