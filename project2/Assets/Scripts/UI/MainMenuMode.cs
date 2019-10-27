using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMode : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMainMenu()
    {
        print("main");
        SceneManager.LoadScene(0);

    }
}
