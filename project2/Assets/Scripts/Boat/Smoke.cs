using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{

    private HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = transform.parent.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!healthManager.getIsAlive())
        {
            // destroy smoke effect
            Destroy(gameObject);
        }
    }
}
