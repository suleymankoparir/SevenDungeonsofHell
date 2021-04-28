using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveKillGroup : MonoBehaviour
{
    public Enemy[] enemies;
    public string objectiveText = "";
    public bool achieved = false;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (!achieved)
        {
            if (aliveEnemy() == 0)
            {
                achieved = true;
            }
        }
    }
    public int aliveEnemy()
    {
        int counter = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                if (enemies[i].currentHealth > 0)
                    counter++;
            }
        }
        return counter;
    }
}
