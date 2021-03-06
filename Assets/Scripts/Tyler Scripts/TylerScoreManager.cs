
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TylerScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public static float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;


    // Start is called before the first frame update
    void Start() {

        if (PlayerPrefs.GetInt("HighScore") != null) {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");

    }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            
            
            scoreCount += pointsPerSecond * Time.deltaTime*TylerMovementScript.acceleration;

        }

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
        
    }
}