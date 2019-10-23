using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public UnityEvent OnSinkingStart; // UnityEvent to trigger sinking animation 

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
        if (health <= 0)
        {
            // trigger sinking animation if health < 0
            OnSinkingStart.Invoke();

            //game over
            SceneManager.LoadScene(2);
        }
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
    public int getHealth()
    {
        return health;
    }
}