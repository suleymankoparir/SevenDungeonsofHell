using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveRegeneration : MonoBehaviour
{
    PlayerCombat pCombat;
    float lasttime = 0;
    public float deltaTakeHitTime = 5f;
    public float deltaFastHealingTime=3f;
    public float fastHealingSpeed = 0.5f;
    public float normalHealingSpeed = 0.1f;
    void Start()
    {
        pCombat = GetComponent<PlayerCombat>();
    }
    public void takeHitLastTime(float time)
    {
        lasttime = time;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (pCombat.currentHealth > 0 && pCombat.currentHealth < pCombat.health && Time.time>lasttime+deltaTakeHitTime)
        {
            float tempHealth = normalHealingSpeed;
            if (Time.time < lasttime +deltaTakeHitTime+ deltaFastHealingTime)
            {
                tempHealth = fastHealingSpeed;
            }
            if (pCombat.health <= pCombat.currentHealth + tempHealth)
            {
                pCombat.currentHealth = pCombat.health;
            }
            else
            {
                pCombat.currentHealth += tempHealth;
            }
        }
    }
}
