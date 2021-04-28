using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    PlayerCombat pCombat;
    public Text health;
    void Start()
    {
        pCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        health.text = pCombat.currentHealth.ToString();
    }

    void FixedUpdate()
    {
        health.text = pCombat.currentHealth.ToString();
    }
}
