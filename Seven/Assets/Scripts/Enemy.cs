using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    Transform player;
    public float currentHealth;
    public Animator anim;
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("TakeHit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (this.GetComponent<EnemyCombat>() != null)
            this.GetComponent<EnemyCombat>().enabled = false;
        if (this.GetComponent<EnemyPathFinder>() != null)
        {
            this.GetComponent<EnemyPathFinder>().canMove(false);
            this.GetComponent<EnemyPathFinder>().enabled = false;
        }
        if (this.GetComponent<DisableSpawner>() != null)
        {
            this.GetComponent<DisableSpawner>().destroyEnemySpawner();
            this.GetComponent<DisableSpawner>().enabled = false;
        }
        anim.SetBool("isDead", true);
        this.GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
