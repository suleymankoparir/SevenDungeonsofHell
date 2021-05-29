using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BossHealthBar : MonoBehaviour
{
    Enemy boss;
    public TMP_Text bossName;
    public Slider health;
    public void setBossName(string name)
    {
        bossName.text = name;
    }
    public void setHealth(float health)
    {
        this.health.value = health;
    }
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Enemy>();
        setBossName(boss.enemyName);
    }
    private static float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (boss != null)
        {
            setHealth(map(boss.currentHealth,0,boss.maxHealth,0,1));
        }
    }
}
