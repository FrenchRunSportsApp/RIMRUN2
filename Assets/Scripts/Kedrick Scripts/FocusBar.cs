using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusBar : MonoBehaviour

{
    public Gradient gradient;
    public Slider slider;
    public Image fill;
    public void SetMaxPower(float power)
    {
        slider.maxValue = power;
        slider.value =  power;
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        gradient.Evaluate(0f);
    }
    public void SetPower(float power)
    {
        slider.value = power;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
