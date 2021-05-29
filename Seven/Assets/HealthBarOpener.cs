using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarOpener : MonoBehaviour
{
    public DialogueTrigger dt;
    bool ended = false;
    GameObject healthbarParent;
    EnemyPathFinder boss;
    void Start()
    {
        healthbarParent = GameObject.FindGameObjectWithTag("BossHealthBar");
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyPathFinder>();
    }

    void FixedUpdate()
    {
        if (dt != null)
        {
            if (ended||dt.ended)
            {
                ended = true;
                if (boss.sawPlayer)
                {
                    healthbarParent.transform.GetChild(0).gameObject.SetActive(true);
                    this.enabled = false;
                }             
            }
        }
    }
}
