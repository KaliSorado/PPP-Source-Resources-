using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeftIndex : MonoBehaviour
{
    ShootArrowsL shootArrowsL;
    TextMeshProUGUI arrowsIndicator;
    
    void Start()
    {
        shootArrowsL = FindObjectOfType<ShootArrowsL>();
        arrowsIndicator = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        arrowsIndicator.text = "="+shootArrowsL.timesCanBeUsed.ToString();
    }
}
