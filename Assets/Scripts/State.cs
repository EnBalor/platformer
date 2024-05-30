using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    public float startValue;
    public float curValue;
    public float maxValue;
    public Image uiBar;


    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = Getpercent();
    }

    private float Getpercent()
    {
        return curValue / maxValue;
    }

    public void Substract(float value)
    {
        curValue = MathF.Max(curValue - value, 0);
    }
}
