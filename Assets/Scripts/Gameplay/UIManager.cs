using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    CurtainManager curtainManager;
    AudioSource soundSelect;
    public AudioSource bgSound;
    public GameObject optionsPanel;
    public bool setPause;
    public bool canPause = true;
    // Buttons
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject B4;

    void Start()
    {
        soundSelect = GetComponent<AudioSource>();
        curtainManager = FindObjectOfType<CurtainManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setPause = !setPause;
            if (setPause && canPause)
            {
                Pause();
            }else{
                Reanude();
            }
        }
    }

    public void Pause()
    {
        if (canPause)
        {
            bgSound.volume = 0.5f;
            soundSelect.Play();
            Time.timeScale = 0;
            optionsPanel.SetActive(true);
            B1.SetActive(false);
            B2.SetActive(false);
            B3.SetActive(false);
            B4.SetActive(false);
        }
    }

    public void Reanude()
    {
        bgSound.volume = 1;
        soundSelect.Play();
        setPause = false;
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
        B1.SetActive(true);
        B2.SetActive(true);
        B3.SetActive(true);
        B4.SetActive(true);
    }

    public void ReturnMainMenu()
    {
        bgSound.volume = 1;
        soundSelect.Play();
        curtainManager.initTimer = true;
    }

    public void ExitGame()
    {
        bgSound.volume = 1;
        soundSelect.Play();
        Application.Quit();
    }

}
