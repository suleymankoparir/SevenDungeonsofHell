using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedofSloth : MonoBehaviour
{
    public Button button;
    public float deltatimeButton = 5f;
    float lasttimeButton = 0;

    float skillDistance = 8f;
    public LayerMask enemyLayer;
    public float deltatime=4f;
    float lasttime = 0f;
    List<GameObject> stunnedEnemies;
    public bool debug = false;
    public void stunEnemy()
    {
        stunnedEnemies.Clear();
        Collider2D[] hitArea = Physics2D.OverlapCircleAll(transform.position, skillDistance, enemyLayer);
        for (int i = 0; i < hitArea.Length; i++)
        {
            button.interactable = false;
            lasttimeButton = Time.time;

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
    }
    void Start()
    {
        if (!debug && PlayerPrefs.GetInt("Stun", -1) == -1)
        {
            button.interactable = false;
            //button.enabled = false;
            this.enabled = false;
        }
        stunnedEnemies = new List<GameObject>();

    }
    void FixedUpdate()
    {
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
        if (!button.IsInteractable() && Time.time > lasttimeButton + deltatimeButton)
        {
            button.interactable = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, skillDistance);
    }
}
