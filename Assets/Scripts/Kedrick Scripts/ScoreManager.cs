
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public Text focusText;
    public Text zoneText;

    public static float scoreCount;
    public static float focusCount;
    public readonly int focusMax = 100;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;


    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("HighScore") != null)
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            if (focusCount! < focusMax)
            {
                focusCount += (pointsPerSecond / 9) * (Time.deltaTime);
            }
            scoreCount += pointsPerSecond * Time.deltaTime * KedrickMovementScript.acceleration * (.2f * focusCount);
            if (KedrickMovementScript.zonePowerupMeter! <= 100)
            {
                KedrickMovementScript.zonePowerupMeter += (pointsPerSecond * Time.deltaTime * KedrickMovementScript.acceleration) / 15;
            }
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