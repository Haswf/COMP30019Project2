using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFollower : MonoBehaviour
{
    public float scale;
    public float distance;

    public float minCameraDistance;
    public float maxCameraDistance;
    public float cameraYAngleMin;
    public float cameraYAngleMax;

    public GameObject target;
    private float _mouseX;
    private float _mouseY;

    public void Start()
    {
       // target = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            // Make the camera look at target
            transform.LookAt(target.transform);
            // Read mouse input
            _mouseX += Input.GetAxis("Mouse X");
            _mouseY += Input.GetAxis("Mouse Y");
            // Change camera distance from scroll input
            distance -= Input.mouseScrollDelta.y * scale;
            distance = Mathf.Clamp(distance, minCameraDistance, maxCameraDistance);
            // Clamp camera rotation with respect to Y axis
            _mouseY = Mathf.Clamp(_mouseY, cameraYAngleMin, cameraYAngleMax);
            // Camera transform
            Transform cameraTransform;
            // Apply change to camera rotation.
            (cameraTransform = transform).rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
            // Apply change to camera position.
            cameraTransform.position = target.transform.position - cameraTransform.forward * distance;
        }
    }
}
