using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadFeedback : MonoBehaviour
{
    // Start is called before the first frame update
    //private GameObject _player;
    private Text _feedbackText;
    int line = 0;

    void Start()
    {
       //_player = transform.parent.GetComponent<BoatAccessor>().player;
        _feedbackText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        StreamReader sr = File.OpenText("score.txt");
        String s = "";
        while ((s = sr.ReadLine()) != null && line <2)
        {
            _feedbackText.text += s;
            _feedbackText.text += "\n";
            line += 1;
        }
    


    }
}
