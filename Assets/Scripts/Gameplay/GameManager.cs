using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Scripts
    MaxScore maxScore;
    UIManager uIManager;
    Increasing treeScript;
    LeftMallet leftMallet;
    RightMallet rightMallet;
    ShootArrowsL leftShooter;
    ShootArrowsR rightShooter;

    public GameObject tree;
    public float speedTime = 0.25f;
    public bool gameOver;

    void Start()
    {
        maxScore = FindObjectOfType<MaxScore>();
        uIManager = FindObjectOfType<UIManager>();
        leftShooter = FindObjectOfType<ShootArrowsL>();
        rightShooter = FindObjectOfType<ShootArrowsR>();
        leftMallet = FindObjectOfType<LeftMallet>();
        rightMallet = FindObjectOfType<RightMallet>();
        treeScript = FindObjectOfType<Increasing>();
    }

    void Update()
    {
        if (treeScript.healthPoints <= 0)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            maxScore.SaveMaxScore();
            Time.timeScale = speedTime;
            uIManager.canPause = false;
            leftShooter.canShoot = false;
            rightShooter.canShoot = false;
            leftMallet.malletEnabled = false;
            rightMallet.malletEnabled = false;
        }
    }
}
