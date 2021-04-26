using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    Transform player;
    public float currentHealth;
    public Animator anim;
    public bool takeHitAnimation = true;
    void Start()
    {
        if (takeHitAnimation)
        {
            anim.SetBool("TakeHitAnimation", true);
        }
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
        if (this.GetComponent<AIDestinationSetter>() != null)
        {
            Destroy(this.GetComponent<AIDestinationSetter>());
        }
        if (this.GetComponent<AIPath>() != null)
        {
            Destroy(this.GetComponent<AIPath>());
        }
        if (this.GetComponent<Seeker>() != null)
        {
            Destroy(this.GetComponent<Seeker>());
        }       
        anim.SetBool("isDead", true);
        this.GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
