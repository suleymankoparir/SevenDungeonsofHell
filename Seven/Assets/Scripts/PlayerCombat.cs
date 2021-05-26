using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCombat : MonoBehaviour
{
    public float deltatime = 0.3f;
    public float lasttime = 0;

    Animator anim;
    public Transform attackPointLeft;
    public Transform attackPointRight;
    public Transform attackPointUp;
    public Transform attackPointDown;
    bool dead=false;
    public float health = 100f;
    [HideInInspector]
    public float currentHealth = 100f;
    public float attackRange = 0.5f;
    public float attackDirectionAIRange = 3f;
    public LayerMask enemyLayers;
    public float attackDamage = 30f;
    [HideInInspector]
    public Transform[] directions;
    PlayerMovement pMovement;
    ControlDisable cd;
    PassiveRegeneration passiveRegeneration;
    void Start()
    {
        currentHealth = health;
        anim = this.gameObject.GetComponent<Animator>();
        cd =GameObject.FindGameObjectWithTag("GameSystem").GetComponent<ControlDisable>();
        passiveRegeneration = GetComponent<PassiveRegeneration>();
        pMovement = GetComponent<PlayerMovement>();
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
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);   
        }
    }
    public void Attack()
    {
        if (Time.time > lasttime + deltatime)
        {
            lasttime = Time.time;
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
            if (FindObjectOfType<MainSoundManager>() != null)
                FindObjectOfType<MainSoundManager>().Play("AttackAxe");
            if (max_enemy > 0)
            {
                hitAll(enemies);
                anim.SetFloat("AttackVertical", vertical);
                anim.SetFloat("AttackHorizontal", horizontal);
                anim.SetTrigger("Attack");
            }
            else
            {
                anim.SetFloat("AttackVertical", 0f);
                anim.SetFloat("AttackHorizontal", pMovement.horizontalDirection);
                anim.SetTrigger("Attack");
            }
        }   
    }
    IEnumerator Die()
    {
        cd.disableControls();
        yield return new WaitForSeconds(4f);
        diedScene();
    }
    
    void diedScene()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("dead");
    }
    public void TakeHit(float damage)
    {
        currentHealth -= damage;
        passiveRegeneration.takeHitLastTime(Time.time);
        if (currentHealth <= 0&&!dead)
        {
            dead = true;
            StartCoroutine(Die());
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


