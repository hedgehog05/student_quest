using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public int maxHealth;

    public void SetHealth(int health)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }

}
