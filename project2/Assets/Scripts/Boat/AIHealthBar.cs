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
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
