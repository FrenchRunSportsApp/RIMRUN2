using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KedrickEvents : MonoBehaviour
{
    public static float acceleration = 1;
    public void ReplayGame()
    {
        acceleration = 1;
        SceneManager.LoadScene("Scenes/Kedrick_TestScene 1");
        
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scenes/Start Menu");
    }
}
