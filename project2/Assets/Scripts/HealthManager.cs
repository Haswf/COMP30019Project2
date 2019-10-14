using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public UnityEvent OnSinkingStart; // UnityEvent to trigger sinking animation 
    private bool trigger = true;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        health -= Time.deltaTime;
        if (health <= 120 && trigger)
        {
            // trigger sinking animation if health < 0
            
            OnSinkingStart.Invoke();
            trigger = false;
        }
    }
}