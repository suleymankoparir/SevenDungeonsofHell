using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public NextLevel nLevel;
    PlayerCombat pCombat;
    Transform enemyList;
    public Text health, enemy;
    void Start()
    {
        pCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        health.text = pCombat.currentHealth.ToString();
        enemyList = GameObject.FindGameObjectWithTag("Enemies").transform;
    }

    int aliveEnemy()
    {
        int counter = 0;
        for(int i = 0; i < enemyList.childCount; i++)
        {
            if (enemyList.GetChild(i).GetComponent<Enemy>() != null)
            {
                if (enemyList.GetChild(i).GetComponent<Enemy>().currentHealth > 0)
                    counter++;
            }
        }
        return counter;
    }
    void FixedUpdate()
    {
        health.text = pCombat.currentHealth.ToString();
        enemy.text = aliveEnemy().ToString();
        if (aliveEnemy() == 0)
        {
            nLevel.nextLevel();
            this.enabled = false;
        }
    }
}
