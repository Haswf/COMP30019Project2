using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMode : MonoBehaviour
{
    // Start is called before the first frame update
    public void TutorialBegin()
    {
        print("tutorial");
        SceneManager.LoadScene(3);

    }
}
