using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialIndicator : MonoBehaviour
{
    //public GameObject boat;
    private Text _tutorialText;

    private int _step;

    private int _timer;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _tutorialText = GetComponent<Text>();
        _step = 0;
        _tutorialText.text = "Welcome to Sink the Bismarck!\n Press W to speed up the battleship.";
    }

    // Update is called once per frame
    void Update()
    {

        if (_step == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _timer += 1;
                if(_timer == 500)
                {
                    _tutorialText.text = "Well done! Press A to left rotate the battleship.";
                    _timer = 0;
                }

            }
            if (Input.GetKey(KeyCode.A))
            {
                _timer += 1;
                if(_timer == 500)
                {
                    _tutorialText.text = "Well done! Now you know how to move the boat!\n Move the mouse to look around.";
                    _step = 1;
                    _timer = 0;
                }

            }
        }

        if (_step == 1)
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                _tutorialText.text = "Move your mouse to aim.\n";
                _step = 2;
            }
        }

        if (_step == 2)
        {
            if (Input.GetAxis("Mouse Y") > 0)
            {
                _tutorialText.text = "Use mouse scroll to zoom camera. \n";

            }

            if (Input.mouseScrollDelta.y > 0)
            {
                _tutorialText.text = "Left Click to fire.\n";
                _step = 3;
            }
        }

        if (_step == 3)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _tutorialText.text = "Press C to change perspective.\n";
                _step = 4;
            }
        }
        
        if (_step == 4)
        {
            if (Input.GetKey(KeyCode.C))
            {
                _tutorialText.text = "Press Z to switch back to the boat.\n";
            }
            if (Input.GetKey(KeyCode.Z))
            {
                _tutorialText.text = "Left click your mouse to fire.\n";
                _step = 5;
            }
        }
        
        if (_step == 5)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _tutorialText.text = "Nice shot! Press X to follow the projectiles.\n";
                
            }
            if (Input.GetKey(KeyCode.X))
            {
                _tutorialText.text = "Well done! Now you know how to follow bullets.";
                _step = 6;
            }
        }

        if (_step == 6)
        {
            _timer += 1;
            _tutorialText.text = "The green bar stands for your health \n" +
                                 "The blue bar indicates loading \n time left until you can shot.";
            if (_timer > 500)
            {
                _step = 7;
            }
        }

        if (_step == 7)
        {
            _tutorialText.text = "Congratulation!\n Right click to quit";
            _step = 8;
        }
        if (_step == 8)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                SceneManager.LoadScene(0);
            }
        }
    }



}