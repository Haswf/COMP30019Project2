using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // _battleshipCamera = GetComponent<Camera>();
        // make cursor invisible
        Cursor.visible = true;
        // lock cursor at the center of the screen
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
