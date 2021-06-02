using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerofJustice : MonoBehaviour
{
    public Button button;
    public float deltatime = 5f;
    float lasttime = 0;
    public float skillDistance = 8f;
    public float damage = 100f;
    public LayerMask enemyLayer;
    public bool debug = false;
    PlayerCombat pCombat;
    private void Start()
    {
        pCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        if (!debug && PlayerPrefs.GetInt("Hammer", -1) == -1)
        {
            button.interactable = false;
            //button.enabled = false;
            this.enabled = false;
        }
    }
    public void hammerEnemy()
    {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, skillDistance, enemyLayer);
            if (hit.Length > 0)
            {
                if (FindObjectOfType<MainSoundManager>() != null)
                    FindObjectOfType<MainSoundManager>().Play("Wrath");
                GetComponent<Animator>().SetTrigger("Hammer");
                button.interactable = false;
                lasttime = Time.time;
                for(int j = 0; j < hit.Length; j++)
                {
                    if (hit[j].gameObject.GetComponent<Enemy>() != null)
                    {
                        if(hit[j].gameObject.tag!="Boss")
                            hit[j].gameObject.GetComponent<Enemy>().takeDamage(hit[j].gameObject.GetComponent<Enemy>().currentHealth);
                        else
                            hit[j].gameObject.GetComponent<Enemy>().takeDamage(damage);
                }
                }

            }
    }
    private void FixedUpdate()
    {
        if (!button.IsInteractable() && Time.time > lasttime + deltatime)
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
