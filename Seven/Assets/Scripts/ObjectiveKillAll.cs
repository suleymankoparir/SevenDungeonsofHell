using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveKillAll : MonoBehaviour
{
    public string objectiveText = "";
    public bool achieved = false;
    public Transform enemies;
    void Start()
    {
        //enemies = GameObject.FindGameObjectWithTag("Enemies").transform;
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
        for (int i = 0; i < enemies.childCount; i++)
        {
            if (enemies.GetChild(i).GetComponent<Enemy>() != null)
            {
                if (enemies.GetChild(i).GetComponent<Enemy>().currentHealth > 0)
                    counter++;
            }
        }
        return counter;
    }
}
