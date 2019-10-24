using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MoveCrossHair : MonoBehaviour
{
    private GameObject _playerBoat;
    private Transform _target;

    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        _playerBoat = transform.parent.GetComponent<BoatAccessor>().player;
        _target = _playerBoat.transform.Find("Target").gameObject.GetComponent<Transform>();
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
                rect.transform.position = new Vector3(cameras[i].WorldToScreenPoint(_target.position).x, 
                    cameras[i].WorldToScreenPoint(_target.position).y,
                    0);
                break;
            }
        }
      
    }
}
