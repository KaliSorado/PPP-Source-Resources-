using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreComponent;
    public int score;
    
    void Start()
    {
        scoreComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreComponent.text = "Score: " + score.ToString();
    }
}
