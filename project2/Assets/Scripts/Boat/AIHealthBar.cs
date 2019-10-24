using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIHealthBar : MonoBehaviour
{

    private HealthManager healthManager;
    [SerializeField]
    private Image foreGround; 
    // Start is called before the first frame update
    void Start()
    {
        healthManager = transform.parent.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreGround.fillAmount = 1.0f * healthManager.getHealth() / healthManager.getMaxHealth();
    }
    private void LateUpdate()
    {    
        // Create an array of all camera on the scene
        Camera[] cameras = new Camera[Camera.allCamerasCount]; 
        Camera.GetAllCameras(cameras);
        
        for (int i=0; i<cameras.Length; i++){
            if (cameras[i].enabled)
            {    
                // Move the crosshair according current camera
                transform.LookAt(cameras[i].transform);
                break;
            }
        }
        transform.Rotate(0, 180, 0);
    }
}
