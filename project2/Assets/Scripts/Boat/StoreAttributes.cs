using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAttributes : MonoBehaviour
{
    public int yourHealth;
    public float yourShellSpeed;
    public float yourloadingTime;
    // Start is called before the first frame update
    void Start()
    {
        yourHealth = GetComponent<HealthManager>().getMaxHealth();
        yourloadingTime = GetComponent<GunController>().getLoadingTime();
        yourShellSpeed = GetComponent<GunController>().getShellSpeed();
        //could use setter to change it
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
