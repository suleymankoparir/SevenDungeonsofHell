using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    PlayerCombat pCombat;
    public HealthBarScript healthBar;
    //public Text health;
    void Start()
    {
        pCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
       // health.text = pCombat.currentHealth.ToString();
    }
    private static float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }
    void FixedUpdate()
    {
        healthBar.setSliderValue(map(pCombat.currentHealth, 0, pCombat.health, 0, 1));
        //health.text = pCombat.currentHealth.ToString();
    }
}
