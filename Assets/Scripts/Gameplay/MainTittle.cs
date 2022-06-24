using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTittle : MonoBehaviour
{
    MainCurtain mainCurtain;
    AudioSource soundSelect;

    public GameObject startButton;
    public GameObject exitButton;
    public GameObject ctrlButton;
    public GameObject ctrlInfo;

    private bool showInfo;

    void Start()
    {
        mainCurtain = FindObjectOfType<MainCurtain>();
        soundSelect = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        soundSelect.Play();
        mainCurtain.closeCurtain = true;
        startButton.SetActive(false);
        exitButton.SetActive(false);
        ctrlButton.SetActive(false);
    }

    public void ExitGame()
    {
        soundSelect.Play();
        mainCurtain.closeCurtainExit = true;
        startButton.SetActive(false);
        exitButton.SetActive(false);
        ctrlButton.SetActive(false);
    }

    public void Controls()
    {
        soundSelect.Play();
        showInfo = !showInfo;
    }

    void Update()
    {
        if (showInfo)
        {
            ctrlInfo.SetActive(true);
            startButton.SetActive(false);
            exitButton.SetActive(false);
        }else{
            ctrlInfo.SetActive(false);
            startButton.SetActive(true);
            exitButton.SetActive(true);
        }
    }
}
