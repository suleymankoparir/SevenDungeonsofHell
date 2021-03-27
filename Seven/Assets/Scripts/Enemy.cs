using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    Transform player;
    public int currentHealth;
    Animator anim;
    public LayerMask obstacleLayer;
    public float sightDistance = 50;
    public bool takeHitAnimation=false;
    public bool walkAnimation = false;
    void Start()
    {
        currentHealth = maxHealth;
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim.SetBool("TakeHitAnimation", takeHitAnimation);
    }

    private void FixedUpdate()
    {
        Vector2 direction = player.position - transform.position;
        if(direction.magnitude<sightDistance)
        {
            if (direction.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(takeHitAnimation)
            anim.SetTrigger("TakeHit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("isDead", true);
        this.GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, sightDistance);
    }
}
