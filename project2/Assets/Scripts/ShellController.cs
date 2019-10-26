using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour

{    
    // Explosion effect after collision
    public GameObject explosionPrefab;
    public GameObject splashPrefab;
    public float EffectScale;

    public int waterLevel;
    // How many damage should this shell produce
    public int damage;
    public int shipID;
    public GameObject FiringBoat;
    // Start is called before the first frame update
    void Start()
    {
        EffectScale = 10;
        waterLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HitWater();
    }


    public void HitWater()
    {
        if (transform.position.y < waterLevel)
        {
            GameObject splash = Instantiate(splashPrefab, transform.position, transform.rotation);
            splash.transform.localScale = new Vector3(EffectScale, EffectScale, EffectScale);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {    
        // Avoid projectiles from collision with other projectiles
        if (!other.gameObject.CompareTag("Projectile") && other.gameObject != FiringBoat)
        {
            if (other.gameObject.CompareTag("Battleship"))
            {
                // deduct health of battleship
                other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
                FiringBoat.GetComponent<Experience>().increaseExp(damage/10);
            }
            Explode();
        }
    }

    public void Explode()
    {    
        // Instantiate explosion effect at collision point
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        // Destroy the shell after explosion
        explosion.transform.localScale = new Vector3(EffectScale, EffectScale ,EffectScale);
        Destroy(gameObject);
    }
}
