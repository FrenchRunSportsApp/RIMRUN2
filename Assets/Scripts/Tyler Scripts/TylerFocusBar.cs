using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TylerFocusBar : MonoBehaviour

{
    public Gradient gradient;
    public Slider slider1;
    public Image fill;


    public void SetMaxPower(float power)
    {
        slider1.maxValue = power;
        slider1.value =  power;
    }
    public void SetMaxHealth(float health)
    {
        slider1.maxValue = health;
        slider1.value = health;
        gradient.Evaluate(0f);
    }
    public void SetPower(float power)
    {
        slider1.value = power;
    }
    public void SetHealth(float health)
    {
        slider1.value = health;
        fill.color = gradient.Evaluate(slider1.normalizedValue);
    }
}
