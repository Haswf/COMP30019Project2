using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassRotater : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _playerBoat;
    private RectTransform _rectTransform;
    
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _playerBoat = transform.parent.GetComponent<BoatAccessor>().player;
    }

    // Update is called once per frame
    void Update()
    {    
        _rectTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _playerBoat.transform.rotation.eulerAngles.y));
    }
}
