using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour

{    
    // Explosion effect after collision
    public GameObject explosionEffect;
    // How many damage should this shell produce
    public int Damage;
    public int ShipID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // deduct health of battleship
            //print("explore");
            col.gameObject.GetComponent<HealthManager>().TakeDamage(Damage);
            Explode();
        }
    }

    public void Explode()
    {    
        // Instantiate explosion effect at collision point
        Instantiate(explosionEffect, transform.position, transform.rotation);
        // Destroy the shell after explosion
        Destroy(gameObject);
    }
}
