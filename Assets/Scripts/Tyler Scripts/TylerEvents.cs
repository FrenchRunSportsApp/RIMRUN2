using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TylerEvents : MonoBehaviour
{
    public static float acceleration = 1;
    public void ReplayGame()
    {
        SceneManager.LoadScene("Scenes/Tyler_TestScene 1");
        acceleration = 1;
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scenes/Start Menu");
    }
}
