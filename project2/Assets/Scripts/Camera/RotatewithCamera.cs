using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RotatewithCamera : MonoBehaviour
{
    public bool front_fire;
    
    // The aiming object
    public GameObject aiming;

    // Update is called once per frame
    void Update() {
        // Rotate the barbette to the direction of aiming object
        transform.LookAt(aiming.transform);
        // Ratate the barbette in x axis so it's parallel to the ship
        transform.rotation *= Quaternion.Euler(-90, 0, 0);
        
        // Rotate the back barbette in z axis for 180 degree
        if (!front_fire)
        {
            transform.rotation *= Quaternion.Euler(0, 0, 180);
        }
    }
}
