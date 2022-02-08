using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(int exp) {
        slider.maxValue = exp;
    }

    public void SetCurrentValue(int exp) {
        slider.value = exp;
    }
}
