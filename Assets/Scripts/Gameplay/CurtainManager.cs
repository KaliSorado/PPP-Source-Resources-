using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurtainManager : MonoBehaviour
{
    public Image curtain;
    public float spVisibility = 1;
    //Open
    public bool openTimer = true;
    // Close
    public bool initTimer;
    
    void Start()
    {
        
    }

    void Update()
    {
        curtain.color = new Color(0,0,0,spVisibility);

        //Open
        if (openTimer)
        {
            spVisibility -= 0.02f;
            if (spVisibility < 0)
            {
                openTimer = false;
                spVisibility = 0;
            }
        }else if (initTimer){
            spVisibility += 0.075f;
            if (spVisibility > 1)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
