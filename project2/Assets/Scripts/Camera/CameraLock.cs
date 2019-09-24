using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform Target, Player;
    float mouseX,  mouseY;

    private float distance = 2.0f;
    private const float Y_ANGLE_MAX = 70.0f;
    private const float Y_ANGLE_MIN = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        // make cursor invisible
        Cursor.visible = false;
        // lock cursor at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);
    }

    private void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.position = Target.position - transform.forward * distance;
    }
}
