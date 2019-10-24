using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialIndicator : MonoBehaviour
{
    //public GameObject boat;
    private Text tutorialText;
    //private HealthManager healthMGR;
    private int step;
    private int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //healthMGR = boat.GetComponent<HealthManager>();
        tutorialText = this.GetComponent<Text>();
        step = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (step == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                print("get key down!!!!!");
                timer += 1;
                if(timer == 100)
                {
                    tutorialText.text = "Well done! Long press A to rotate the boat";
                    timer = 0;
                }

            }
            if (Input.GetKey(KeyCode.A))
            {
                timer += 1;
                if(timer == 100)
                {
                    tutorialText.text = "Well done! Now you know how to move the boat!\n Try to move mouse ";
                    step = 1;
                }

            }
        }

        if (step == 1)
        {
            if (Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0)
            {
                tutorialText.text = "Well done!\n Now you know how to aim !\n Try to press C and change perspective";
                step = 2;
            }


        }
        if (step == 2)
        {
            if (Input.GetKey(KeyCode.C))
            {
                tutorialText.text = "Well done! Press Z to change again";
            }
            if (Input.GetKey(KeyCode.Z))
            {
                tutorialText.text = "Well done! Press X to change again";
            }
            if (Input.GetKey(KeyCode.X))
            {
                tutorialText.text = "Well done! Now you know how to switch perspectives.\n Try left click your mouse";
                step = 3;
            }

        }

        if (step == 3)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                tutorialText.text = "Well done! Now you know how to shoot";
                step = 4;
            }
        }
        if (step == 4)
        {
            tutorialText.text = "Tutorial finished!\n Right click your mouse ,go back to Mainmenu and Enjoy the game";
            step = 5;
        }
        if (step == 5)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                SceneManager.LoadScene(0);
            }
        }
    }



}