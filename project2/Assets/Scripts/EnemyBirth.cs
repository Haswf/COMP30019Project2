using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirth : MonoBehaviour
{
    public Transform enemy;
    private int totalEnemy;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;
    // Start is called before the first frame update
    void Start()
    {
        ArrayList islands = GameObject.Find("Islands").GetComponent<MapGenerator>().islands;
        totalEnemy = Settings.totalEnemy;
        playerPosition = GameObject.Find("Gem_bismack Variant").transform.position;
        int enemies = 0;
        int count = 0;

        while (enemies < totalEnemy)
        {
            enemyPosition = new Vector3(playerPosition.x + Random.Range(-3000, 3000), -8, playerPosition.z + Random.Range(-3000, 3000));
            foreach (GameObject island in islands)
            {
                Vector3 islandPosition = island.transform.position;
                if (Vector3.Distance(islandPosition, enemyPosition) < 4000)
                {
                    count ++;
                    break;
                }
            }
            if (count == 0)
            {
                Instantiate(enemy, enemyPosition, Quaternion.identity);
                enemies++;
            }
            count = 0;
        }
    }
}
