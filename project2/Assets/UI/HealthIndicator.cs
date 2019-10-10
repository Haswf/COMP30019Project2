using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{    
    public GameObject boat;
    private Text healthText;
    private HealthManager healthMGR;
    // Start is called before the first frame update
    void Start()
    {
        healthMGR = boat.GetComponent<HealthManager>();
        healthText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = string.Concat("Health: ", healthMGR.health, '/', healthMGR.maxHealth);
    }
}
