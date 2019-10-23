using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    public float MapMinX = -1000;
    public float MapMaxX = 1000;
    public float MapMinZ = -1000;
    public float MapMaxZ = 1000;
    public GameObject[] IslandPrefab;
    
    public int time;
    public int IslandCount = 5;
    public Material[] skyboxs;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skyboxs[time];
        CreateIslands();
    }

    private void CreateIslands()
    {
        for (int i = 0; i < IslandCount; i++)
        {
            float x = Random.Range(MapMinX, MapMaxX);
            float z = Random.Range(MapMinZ, MapMaxZ);
            GameObject prefab = RandomChoosePrefab();
            // Determine the scale of each island
            float scale = Random.Range(0.5f, 1.5f);
            // Choose rotation of the island
            GameObject island = Instantiate(prefab, Vector3.one, Quaternion.identity);
            island.transform.SetParent(transform);
            // Change the scale of the island
            island.transform.localScale = Vector3.one * scale;
            island.transform.position = new Vector3(x, -50, z);
        }
    }
    

    private GameObject RandomChoosePrefab()
    {    
        // Randomly choose a prefab
        return IslandPrefab[Random.Range(0, IslandPrefab.Length)];
    }
}