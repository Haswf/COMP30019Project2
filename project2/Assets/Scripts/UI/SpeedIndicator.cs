using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedIndicator : MonoBehaviour
{
    private GameObject _player;

    private Rigidbody boatRB;

    private Text displayText;

    private BoatController bc;
    // Start is called before the first frame update
    void Start()
    {
        boatRB = GetComponent<Rigidbody>();
        displayText = GetComponent<Text>();
        _player = transform.parent.GetComponent<BoatAccessor>().player;
        bc = _player.GetComponent<BoatController>();
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = String.Concat("Speed: ", Math.Round(bc.CurrentSpeed, 2));
    }
}
