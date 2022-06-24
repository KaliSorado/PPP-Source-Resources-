using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCurtain : MonoBehaviour
{
    public Image curtain;
    public float spVisibility = 1;
    //Open | Close
    public bool openCurtain = true;
    public bool closeCurtain;
    public bool closeCurtainExit;

    void Update()
    {
        curtain.color = new Color(0,0,0,spVisibility);

        //Open
        if (openCurtain)
        {
            spVisibility -= 0.02f;
            if (spVisibility < 0)
            {
                openCurtain = false;
                spVisibility = 0;
            }
        }else if (closeCurtain){
            spVisibility += 0.04f;
            if (spVisibility > 1)
            {
                SceneManager.LoadScene("Gameplay");
            }
        }

        if (closeCurtainExit)
        {
            spVisibility += 0.05f;
            if (spVisibility > 1)
            {
                Application.Quit();
            }
        }
    }
}
