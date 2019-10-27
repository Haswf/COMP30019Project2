using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{    
    private GameObject _player;
    private HealthManager _healthManager;

    private SimpleHealthBar _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        _player = transform.parent.parent.GetComponent<BoatAccessor>().player;
        _healthManager = _player.GetComponent<HealthManager>();
        _healthBar = GetComponent<SimpleHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.UpdateBar(_healthManager.getHealth(), _healthManager.getMaxHealth());
    }
}
