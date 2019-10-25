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
    
    //remember when call these methods need to has skill points
    public void levelUpHealth()
    {
        GetComponent<HealthManager>().setMaxHealth(yourHealth+1000);
        yourHealth = GetComponent<HealthManager>().getMaxHealth();
        
    }

    public void levelUpLoading()
    {
        GetComponent<GunController>().setLoadingTime(yourloadingTime*0.95f);
        yourloadingTime = GetComponent<GunController>().getLoadingTime();
    }

    public void levelUpShellSpeed()
    {
        GetComponent<GunController>().setShellSpeed(yourShellSpeed*1.05f);
        yourShellSpeed = GetComponent<GunController>().getShellSpeed();
    }
    

}
