using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterPauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("Scenes/Master");
        MasterMovementScript.acceleration = 1;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);


    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scenes/Start Menu");
        Time.timeScale = 1f;
    }
}
