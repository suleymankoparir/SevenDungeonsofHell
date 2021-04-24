using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedofSloth : MonoBehaviour
{
    float skillDistance = 8f;
    public LayerMask enemyLayer;
    public float deltatime=4f;
    float lasttime = 0f;
    List<GameObject> stunnedEnemies;

    public void stunEnemy()
    {
        stunnedEnemies.Clear();
        Collider2D[] hitArea = Physics2D.OverlapCircleAll(transform.position, skillDistance, enemyLayer);
        for (int i = 0; i < hitArea.Length; i++)
        {
            stunnedEnemies.Add(hitArea[i].gameObject);
            if (hitArea[i].gameObject.GetComponent<EnemyPathFinder>()!=null)
            {
                hitArea[i].gameObject.GetComponent<EnemyPathFinder>().enableStun();
            }
            if (hitArea[i].gameObject.GetComponent<EnemyCombat>() != null)
            {
                hitArea[i].gameObject.GetComponent<EnemyCombat>().stunned=true;
            }
        }
        lasttime = Time.time;
        Debug.Log("2 Stunned: " + stunnedEnemies.Count);
    }
    void Start()
    {
        stunnedEnemies = new List<GameObject>();

    }
    void FixedUpdate()
    {
        Debug.Log("1 Stunned: " + stunnedEnemies.Count);
        if (stunnedEnemies.Count > 0 && Time.time>lasttime+deltatime)
        {
            foreach (GameObject item in stunnedEnemies)
            {
                if (item.GetComponent<EnemyPathFinder>() != null)
                {
                    item.GetComponent<EnemyPathFinder>().disableStun();
                }
                if (item.GetComponent<EnemyCombat>() != null)
                {
                    item.GetComponent<EnemyCombat>().stunned = false;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, skillDistance);
    }
}
