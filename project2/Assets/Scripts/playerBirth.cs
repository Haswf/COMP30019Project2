using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBirth : MonoBehaviour
{
    private Vector3 playerPosition;
    private bool isInsideIslands = true;
    // Start is called before the first frame update
    void Start()
    {
        ArrayList islands = GameObject.Find("Islands").GetComponent<MapGenerator>().islands;
        int count = 0;
        while (isInsideIslands)
        {
            playerPosition = new Vector3(playerPosition.x + Random.Range(-8000, 8000), -8, playerPosition.z + Random.Range(-8000, 8000));
            foreach (GameObject island in islands)
            {
                Vector3 islandPosition = island.transform.position;
                if (Vector3.Distance(islandPosition, playerPosition) < 4000)
                {
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                transform.position = playerPosition;
                isInsideIslands = false;
            }
            count = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
