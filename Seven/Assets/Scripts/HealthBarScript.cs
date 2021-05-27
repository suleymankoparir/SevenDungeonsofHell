using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Slider healthSlider;
    public void Start()
    {
        healthSlider = GetComponent<Slider>();
    }
    public void setSliderValue(float value)
    {
        if (healthSlider != null)
        {
            healthSlider.value = value;
        }      
    }
}
