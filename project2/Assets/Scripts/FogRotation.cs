using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}
