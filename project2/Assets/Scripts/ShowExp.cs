using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowExp : MonoBehaviour
{
    public GameObject boat;

    private Text displayText;
    private Experience Ex;
    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<Text>();
        Ex = boat.GetComponent<Experience>();
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = String.Concat("Level: ",Ex.getlevel(),"\n","Exp: ", Ex.getExp(), "/", Ex.getMaxExp());
    }
}
