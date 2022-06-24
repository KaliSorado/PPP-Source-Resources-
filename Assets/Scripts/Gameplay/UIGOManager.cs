using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGOManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public AudioSource bgSound;
    GameManager gameManager;
    CurtainManager curtainManager;
    AudioSource soundSelect;
    // Buttons
    public GameObject B1;
    public GameObject B2;

    void Start()
    {
        soundSelect = GetComponent<AudioSource>();
        curtainManager = FindObjectOfType<CurtainManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GameOver()
    {
        bgSound.volume = 0.5f;
        gameManager.speedTime = 0;
        optionsPanel.SetActive(true);
    }

    public void ReturnMainMenu()
    {
        soundSelect.Play();
        curtainManager.initTimer = true;
        B1.SetActive(false);
        B2.SetActive(false);
    }

    public void ExitGame()
    {
        B1.SetActive(false);
        B2.SetActive(false);
        soundSelect.Play();
        Application.Quit();
    }
}
