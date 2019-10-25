using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTimeIndicator : MonoBehaviour
{
    public GameObject _playerBoat;
    private GunController _gunController;
    private SimpleHealthBar _loadingBar;
    // Start is called before the first frame update
    void Start()
    {
        _playerBoat = transform.parent.parent.GetComponent<BoatAccessor>().player;
        _gunController = _playerBoat.GetComponent<GunController>();
        _loadingBar = GetComponent<SimpleHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        _loadingBar.UpdateBar(_gunController.guns[0].loadingTimeLeft, Settings.PlayerLoadingTime);
    }
}