﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTimeIndicator : MonoBehaviour
{
    public GameObject crossHair;
    private Text _loadingTimerText;
    public GameObject playerBoat;
    private Transform _transform;
    private ProjectileShooter _shooter;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _loadingTimerText = GetComponent<Text>();
        _shooter = playerBoat.GetComponent<ProjectileShooter>();
        _transform.SetParent(crossHair.transform);
    }

    // Update is called once per frame
    void Update()
    {    
        _loadingTimerText.text = _shooter.barrels[0].loadingTimeLeft.ToString("F");
        _transform.localPosition = new Vector3(0, -10, 0);
    }
}
