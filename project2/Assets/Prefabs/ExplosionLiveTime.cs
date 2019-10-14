using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLiveTime : MonoBehaviour
{
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time + .5f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (time < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
