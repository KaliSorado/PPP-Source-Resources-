using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScore : MonoBehaviour
{
    Score scoreScript;
    TextMeshProUGUI scoreComponent;
    public int maxScore;
    
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("scoreSaved");
        scoreScript = FindObjectOfType<Score>();
        scoreComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreComponent.text = "Max. Score: " + maxScore.ToString();
    }

    public void SaveMaxScore()
    {
        if (scoreScript.score > maxScore)
        {
            maxScore = scoreScript.score;
            PlayerPrefs.SetInt("scoreSaved", maxScore);
        }
    }

}
