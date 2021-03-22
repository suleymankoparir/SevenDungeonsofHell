using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    public Transform attackPointLeft;
    public Transform attackPointRight;
    public Transform attackPointUp;
    public Transform attackPointDown;

    public float attackRange = 0.5f;
    public float attackDirectionAIRange = 3f;
    public LayerMask enemyLayers;
    public int attackDamage = 30;
    Transform[] directions;
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();

        directions = new Transform[4];
        directions[0] = attackPointRight;
        directions[1] = attackPointUp;
        directions[2] = attackPointDown;
        directions[3] = attackPointRight;
    }

    void Update()
    {
        
    }
    void hitAll(Collider2D[] area)
    {
        foreach (Collider2D enemy in area)
        {
            enemy.GetComponent<Enemy>().takeDamage(30);   
        }
    }
    public void Attack()
    {    
        Collider2D[] enemies;
        int max_enemy = 0;
        float vertical = 0;
        float horizontal = 0;


        Collider2D[] hitRight = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);
        Collider2D[] hitLeft = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);           
        Collider2D[] hitUp = Physics2D.OverlapCircleAll(attackPointUp.position, attackRange, enemyLayers);
        Collider2D[] hitDown = Physics2D.OverlapCircleAll(attackPointDown.position, attackRange, enemyLayers);

        
        enemies = hitRight;
        max_enemy = hitRight.Length;
        vertical = 1;

        if (hitLeft.Length > max_enemy)
        {
            enemies = hitLeft;
            max_enemy = hitLeft.Length;
            vertical = -1;
        }          
        if (hitUp.Length > max_enemy)
        {
            enemies = hitUp;
            max_enemy = hitUp.Length;
            vertical = 0;
            horizontal = 1;
        }          
        if (hitDown.Length > max_enemy)
        {
            enemies = hitDown;
            max_enemy = hitDown.Length;
            horizontal = -1;
        }

        if (max_enemy > 0)
        {
           hitAll(enemies);
           anim.SetFloat("AttackVertical", vertical);
           anim.SetFloat("AttackHorizontal", horizontal);
           anim.SetTrigger("Attack");
        }
        else
        {
            anim.SetTrigger("Attack");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
        Gizmos.DrawWireSphere(attackPointUp.position, attackRange);
        Gizmos.DrawWireSphere(attackPointDown.position, attackRange);
    }
}


