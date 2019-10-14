using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkEvent : MonoBehaviour 
{

    private GameObject[] explosionEffect = new GameObject[5];
    public GameObject explosionEffect1;
    public GameObject explosionEffect2;
    public GameObject explosionEffect3;
    public GameObject explosionEffect4;
    public GameObject explosionEffect5;
    private float deltaTime = 0;
    public void Start()
    {
        explosionEffect[0] = explosionEffect1;
        explosionEffect[1] = explosionEffect2;
        explosionEffect[2] = explosionEffect3;
        explosionEffect[3] = explosionEffect4;
        explosionEffect[4] = explosionEffect5;
    }
    public void  Sink()
    {

        InvokeRepeating("Explode", 0.5f, 2.0f);
        InvokeRepeating("BoatSinking", 0.5f, 0.01f);
        
    }

    private void Explode()
    {
        Vector3 pos;
        pos = transform.position + new Vector3(Random.Range(-2f,2f), Random.Range(0f , 4.0f), Random.Range(-11.0f, 11.0f));
        Instantiate(explosionEffect[Random.Range(0, 4)], pos, transform.rotation);
    }

    private void BoatSinking()
    {
        deltaTime += Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(-deltaTime *0.5f ,0,0);
        if (transform.localRotation.x >= -89.0f) { 
            transform.localRotation = rotation;
        }
    }
}
