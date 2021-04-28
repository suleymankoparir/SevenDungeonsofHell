using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveKill : MonoBehaviour
{
    public Enemy enemy;
    public string objectiveText = "";
    public bool achieved = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!achieved)
        {
            if (enemy.currentHealth <= 0)
            {
                achieved=true;
            }
        }
    }
}
