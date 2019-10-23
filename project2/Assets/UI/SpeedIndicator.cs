using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedIndicator : MonoBehaviour
{
    private GameObject _playerBoat;
    private Rigidbody _boatRigidbody;
    private Text _textToDisplay;
    private BoatController _boatController;
    // Start is called before the first frame update
    void Start()
    {
        _playerBoat = transform.parent.GetComponent<BoatAccessor>().player;
        _boatRigidbody = GetComponent<Rigidbody>();
        _textToDisplay = GetComponent<Text>();
        _boatController = _playerBoat.GetComponent<BoatController>();
    }

    // Update is called once per frame
    void Update()
    {
        _textToDisplay.text = String.Concat("Speed: ", Math.Round(_boatController.CurrentSpeed, 2));
    }
}
