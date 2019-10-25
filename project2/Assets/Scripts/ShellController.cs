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

    public void OnCollisionEnter(Collision col)
    {    
        // Avoid shell from collision with its launcher
        if (col.gameObject.GetInstanceID() != shipID && !col.gameObject.GetComponent<ShellController>())
        {
            if (col.gameObject.CompareTag("Battleship"))
            {
                // deduct health of battleship
                if (col.gameObject != FiringBoat)
                {
                    col.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
                    FiringBoat.GetComponent<Experience>().increaseExp(damage/10);
                }
                
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
