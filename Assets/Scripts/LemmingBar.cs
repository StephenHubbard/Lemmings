using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LemmingBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetFillValue(int value)
    {
        slider.value = value;
    }
}
