using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public UnityEvent OnSinkingStart; // UnityEvent to trigger sinking animation 
    public int maxHealth;
    private int health;
    private bool isAlive = true;
    private float timer = -1;
    private float deltaTime = 0;
    private int trigger = 0;
    private int enemyNumber;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        if(transform.name.Equals("Gem_bismack Variant")){
            health = Settings.PlayerMaxHealth;
            maxHealth = Settings.PlayerMaxHealth;
        }
        enemyNumber = Settings.EnemyCount;
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
            transform.Translate(new Vector3(0, 0, 0));
            deltaTime += Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(-deltaTime * 1f, transform.rotation.y, transform.rotation.z);

            if (transform.localRotation.x >= -89.0f)
            {
                transform.localRotation = rotation;
                transform.position -= new Vector3(0, 0.01f, 0);

                if (deltaTime > trigger)
                {
                    // create explosion every one second
                    OnSinkingStart.Invoke();
                    trigger += 1;
                }
            }
            if (timer < 0)
            {

                timer = 0;
            }
            else if (timer >= 30)
            {
                // end the game
                GameObject[] battleShips = GameObject.FindGameObjectsWithTag("Battleship");
                int count = 0;
                foreach (GameObject battleship in battleShips)
                {
                    if (battleship.name.Equals("Gem_bismack Variant"))
                    {
                        if (!battleship.GetComponent<HealthManager>().getIsAlive())
                        {
                            SceneManager.LoadScene(2);
                        }
                    }
                    else
                    {
                        if (!battleship.GetComponent<HealthManager>().getIsAlive())
                        {
                            count++;

                        }
                    }
                }
                if (count == Settings.totalEnemy)
                {
                    Settings.totalEnemy++;
                    SceneManager.LoadScene(2);
                }

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

    public void setMaxHealth(int newHealth)
    {
        maxHealth = newHealth;
    }
}