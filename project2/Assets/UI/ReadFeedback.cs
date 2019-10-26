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
    
    private int exp = Player.PlayerExp;
    private int level= Player.PlayerLevel;
    private int maxExp= Player.NowMaxExp;
    private Text _feedbackText;
    int line = 0;

    void Start()
    {
        _feedbackText = GetComponent<Text>();
        //_player = transform.parent.GetComponent<BoatAccessor>().player;


    }

    // Update is called once per frame
    void Update()
    {
      _feedbackText.text = String.Concat("Level: ",level,"\n","Exp: ", exp, "/", maxExp,"\n","Skill points: ", Player.PlayerSkillPoints);


    }
}
