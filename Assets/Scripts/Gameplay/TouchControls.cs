using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControls : MonoBehaviour
{
    LeftMallet leftMallet;
    RightMallet rightMallet;
    ShootArrowsL shootArrowsL;
    ShootArrowsR shootArrowsR;

    void Start()
    {
        leftMallet = FindObjectOfType<LeftMallet>();
        rightMallet = FindObjectOfType<RightMallet>();
        shootArrowsL = FindObjectOfType<ShootArrowsL>();
        shootArrowsR = FindObjectOfType<ShootArrowsR>();
    }

    public void ActionLM()
    {
        leftMallet.Action();
    }

    public void ActionRM()
    {
        rightMallet.Action();
    }
    
    public void ActionLS()
    {
        shootArrowsL.Action();
    }

    public void ActionRS()
    {
        shootArrowsR.Action();
    }
}
