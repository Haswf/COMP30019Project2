using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AimingController : MonoBehaviour
{   
    //claim the limitaion of distance of aiming object.
    public float minDistance = 50;
    public float maxDistance = 200;
    private float distance;
    public float scale = 10;
    // Update is called once per frame
    private void Start()
    {
        transform.localPosition = new Vector3(20, 0, 0);
    }
    void Update()
    {
        if (!Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // mouse left and right to rotate the aiming object
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + new Vector3(0, mouseX, 0));

            // mouse up and down to control how far aiming object is.
            distance = Mathf.Clamp(distance+scale*mouseY, minDistance, maxDistance);
            transform.localPosition = transform.forward * distance;
        }
    }
}
