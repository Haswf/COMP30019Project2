using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialIndicator : MonoBehaviour
{    
    //public GameObject boat;
    private Text tutorialText;
    //private HealthManager healthMGR;
    private int step;
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
        //tutorialText.text = "Well done! Press a to rotate the boat";
        if (step == 0) {
            if (Input.GetKey(KeyCode.W))
            {
                print("get key down!!!!!");
                tutorialText.text = "Well done! Press a to rotate the boat";
            }
            if (Input.GetKey(KeyCode.A))
            {
                tutorialText.text = "Well done! Now you know how to move the boat!\n Try to move mouse from left to right";
                step = 1;
            }
        }

        if (step == 1)
        {
            if(Input.GetAxis("Mouse X") != 0)
            {
                tutorialText.text = "Well done!\n Now you know how to aim horizontally\n Try to move mouse up and down";
            }
            if(Input.GetAxis("Mouse Y") != 0)
            {
                tutorialText.text = "Well done!\n Now you know how to aim vertically\n Try press X";
                step = 2;
            }

        }
        if (step == 2)
        {
            if (Input.GetKey(KeyCode.X))
            {
                tutorialText.text = "Well done! Press Z to change again";
            }
            if (Input.GetKey(KeyCode.Z))
            {
                tutorialText.text = "Well done! Press C to change again";
            }
            if (Input.GetKey(KeyCode.C))
            {
                tutorialText.text = "Well done! Now you know how to switch perspectives.\n Try left click your mouse";
                step = 3;
            }

        }

        if(step == 3)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                tutorialText.text = "Well done! Now you know how to shoot";
                step = 4;
            }
        }
        if(step == 4)
        {
            tutorialText.text = "Tutorial finished!\n Enjoy the game";
        }
    }

    void Movement() {
        print("in movement!");
        if (Input.GetKey(KeyCode.W)){
            print("get key down!!!!!");
            tutorialText.text = "Well done! Press a to rotate the boat";
        }
        if (Input.GetKey(KeyCode.A))
        {
            tutorialText.text = "Well done! Now you know how to move the boat!";
        }
    }
}
