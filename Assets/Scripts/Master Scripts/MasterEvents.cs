using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterEvents : MonoBehaviour
{

    public void ReplayGame()
    {
        SceneManager.LoadScene("Scenes/KedrickTestScene 1");
        KedrickMovementScript.acceleration = 1;
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scenes/Start Menu");
    }
}
