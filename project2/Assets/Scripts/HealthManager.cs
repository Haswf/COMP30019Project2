using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int health;
    private bool isAlive = true;
    public UnityEvent OnSinkingStart; // UnityEvent to trigger sinking animation 

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isAlive)
        {
            if (health - damage > 0)
            {
                health -= damage;
            }
            else
            {
                health = 0;
                isAlive = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            // trigger sinking animation if health < 0
            OnSinkingStart.Invoke();
            SceneManager.LoadScene(2);
        }
    }
    public bool getIsAlive()
    {
        return isAlive;
    }
    public int getHealth()
    {
        return health;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
}