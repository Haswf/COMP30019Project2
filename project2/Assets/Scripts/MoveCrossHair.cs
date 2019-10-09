using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MoveCrossHair : MonoBehaviour
{
    public GameObject playerBoat;
    public GameObject aimingPoint;
    public Camera camera;

    private RectTransform rect;

    private GameObject aimming;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        rect.transform.position = new Vector3(camera.WorldToScreenPoint(aimingPoint.transform.position).x, 
            camera.WorldToScreenPoint(aimingPoint.transform.position).y,
            0);
    }
}
