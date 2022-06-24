using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPManager : MonoBehaviour
{
    TextMeshProUGUI txtHP;
    Increasing increasingTree;

    private int treeHP;
    private string treeHPText;
    
    void Start()
    {
        txtHP = GetComponent<TextMeshProUGUI>();
        increasingTree = FindObjectOfType<Increasing>();
    }

    void Update()
    {
        treeHP = increasingTree.healthPoints;
        treeHPText = increasingTree.healthPoints.ToString();
        txtHP.text = treeHPText;
        if (treeHP <= 0)
        {
            txtHP.text = "x";
        }
    }
}
