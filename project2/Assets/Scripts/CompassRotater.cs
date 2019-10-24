using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotater : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _playerBoat;
    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        _playerBoat = transform.parent.GetComponent<BoatAccessor>().player;
    }

    // Update is called once per frame
    void Update()
    {
        rect.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _playerBoat.transform.rotation.eulerAngles.y));
    }
}
