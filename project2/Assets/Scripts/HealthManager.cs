using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public bool isAlive = true;
    public UnityEvent OnSinkingStart; // UnityEvent to trigger sinking animation 
    public float timer = -1;

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
        {  // trigger sinking animation if health < 0
            OnSinkingStart.Invoke();
            if (timer < 0)
            {
              
                timer = 0;
            }
            else if(timer >= 10){
                SceneManager.LoadScene(2);
            }
            timer += Time.deltaTime;
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