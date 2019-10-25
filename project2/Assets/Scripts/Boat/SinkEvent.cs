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
        Explode();
    }
    // instantiate explosion effect
    private void Explode()
    {
        Vector3 pos;
        pos = transform.position + new Vector3(Random.Range(-transform.localScale.x / 10, transform.localScale.x / 10), Random.Range(10f, transform.localScale.y / 5), Random.Range(-transform.localScale.z, transform.localScale.z));
        Instantiate(explosionEffect[Random.Range(0, 4)], pos, transform.rotation);
    }


}