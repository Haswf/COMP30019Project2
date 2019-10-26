using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAccessor : MonoBehaviour
{    
    // Provides access to player boat to other elements on canvas
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Gem_bismack Variant");
    }
}
