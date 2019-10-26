using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShowExp : MonoBehaviour
{
    private GameObject _player;
    private Text _expText;
    private Experience Ex;
    // Start is called before the first frame update
    void Start()
    {
        _player = transform.parent.GetComponent<BoatAccessor>().player;
        _expText = GetComponent<Text>();
        Ex = _player.GetComponent<Experience>();
    }

    // Update is called once per frame
    void Update()
    {
        _expText.text = String.Concat("Level: ",Ex.getlevel(),"\n","Exp: ", Ex.getExp(), "/", Ex.getMaxExp());

        StreamWriter sw = new StreamWriter("score.txt");
        sw.WriteLine(_expText.text);
        sw.Close();

    }
}
