using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public string enemyName="";
    public int maxHealth = 100;
    Transform player;
    public float currentHealth;
    public Animator anim;
    public bool takeHitAnimation = true;
    public float parryMin = 0;
    public float parryMax = 0;
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
        
        float frame = 0;
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Attack"))
        {
            frame=(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length * (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1) * anim.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate);
            if (frame > parryMin && frame < parryMax)
            {
                anim.Play("Attack", 0, 1);
                if (FindObjectOfType<MainSoundManager>() != null)
                    FindObjectOfType<MainSoundManager>().Play("Parry");
                return;
            }
        } 
        currentHealth -= damage;
        anim.SetTrigger("TakeHit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (this.GetComponent<SpriteRenderer>() != null)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else if(transform.GetChild(0)!=null&& transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>() != null)
        {
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        if (this.GetComponent<EnemyCombat>() != null)
            this.GetComponent<EnemyCombat>().enabled = false;
        if (this.GetComponent<EnemyPathFinder>() != null)
        {
            this.GetComponent<EnemyPathFinder>().canMove(false);
            this.GetComponent<EnemyPathFinder>().enabled = false;
        }
        if (this.GetComponent<DisableSpawner>() != null)
        {
            if (FindObjectOfType<MainSoundManager>() != null)
                FindObjectOfType<MainSoundManager>().Play("Scream");
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
