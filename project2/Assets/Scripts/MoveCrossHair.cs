using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MoveCrossHair : MonoBehaviour
{
    private GameObject playerBoat;
    private Transform target;

    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        playerBoat = transform.parent.GetComponent<BoatAccessor>().player;
        rect = GetComponent<RectTransform>();
        target = playerBoat.transform.Find("Target").gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {    
        // Create an array of all camera on the scene
        Camera[] cameras = new Camera[Camera.allCamerasCount]; 
        Camera.GetAllCameras(cameras);
        
        for (int i=0; i<cameras.Length; i++){
            if (cameras[i].enabled)
            {    
                // Move the crosshair according current camera
                rect.transform.position = new Vector3(cameras[i].WorldToScreenPoint(target.position).x, 
                    cameras[i].WorldToScreenPoint(target.position).y,
                    0);
                break;
            }
        }
      
    }
}
