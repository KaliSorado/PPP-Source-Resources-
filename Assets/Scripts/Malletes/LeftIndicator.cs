using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftIndicator : MonoBehaviour
{
    //Scripts, Parameters
    LeftMallet myMallet;
    // Components
    Slider slider;
    public Image image;
    private Color currentColor;
    public Color colorPerf;
    public Color colorGood;
    public Color colorMedium;
    public Color colorLowMedium;
    public Color colorLow;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        myMallet = FindObjectOfType<LeftMallet>();
    }

    void Update()
    {
        image.color = currentColor;
        slider.value = myMallet.timesCanBeUsed;

        if (myMallet.timesCanBeUsed == 50 && myMallet.timesCanBeUsed >= 40)
        {
            currentColor = colorPerf;
        }else if (myMallet.timesCanBeUsed <= 39 && myMallet.timesCanBeUsed >= 30){
            currentColor = colorGood;
        }else if (myMallet.timesCanBeUsed <= 29 && myMallet.timesCanBeUsed >= 20){
            currentColor = colorMedium;
        }else if (myMallet.timesCanBeUsed <= 19 && myMallet.timesCanBeUsed >= 10){
            currentColor = colorLowMedium;
        }else if (myMallet.timesCanBeUsed <= 9){
            currentColor = colorLow;
        }
    }
}
