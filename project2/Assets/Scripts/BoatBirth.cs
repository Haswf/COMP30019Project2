using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBirth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ArrayList islands = GameObject.Find("Islands").GetComponent<MapGenerator>().islands;
        print(islands.Count);
    }
}
