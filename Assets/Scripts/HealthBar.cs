/*
 * Author: Richard
 * Description: Health UI and Player Damage Controller
*/ 

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text text;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

        text.text = "Health: " + health;
    }
}
