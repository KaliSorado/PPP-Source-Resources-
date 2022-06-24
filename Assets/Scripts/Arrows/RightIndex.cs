using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RightIndex : MonoBehaviour
{
    ShootArrowsR shootArrowsR;
    TextMeshProUGUI arrowsIndicator;
    
    void Start()
    {
        shootArrowsR = FindObjectOfType<ShootArrowsR>();
        arrowsIndicator = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        arrowsIndicator.text = shootArrowsR.timesCanBeUsed.ToString()+"=";
    }
}
