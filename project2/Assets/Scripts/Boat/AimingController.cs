using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 1000));
        transform.position = new Vector3(mousePosWorld.x, 0, mousePosWorld.z);
    }
}
