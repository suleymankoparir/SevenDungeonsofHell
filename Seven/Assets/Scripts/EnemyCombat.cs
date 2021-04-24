using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator anim;
    Transform player;
    PlayerCombat pc;

    public float leftPosition = 1f;
    public float rightPosition = 1f;
    public float upPosition = 1f;
    public float downPosition = 1f;
    public float hitDistance = 0.4f;
    public float hitRadius = 0.5f;
    public float attackDelay = 0.7f;
    public float damage = 10f;
    float lastAttackTime = 0;
    public LayerMask playerMask;
    [HideInInspector]
    public bool stunned = false;
    PathfinderControl pathfindercontrol;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pathfindercontrol = GameObject.FindGameObjectWithTag("Pathfinding").GetComponent<PathfinderControl>();
        pc =player.GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 distance = transform.position - player.position;
        if (distance.magnitude < hitDistance)
        {
            if(Time.time>lastAttackTime+attackDelay&&pc.health>0&&pathfindercontrol&&!stunned)
                hitPlayer();
        }
    }
    void hitPlayer()
    {
        Collider2D hitleft = Physics2D.OverlapCircle(transform.position - new Vector3(leftPosition, 0, 0), hitRadius, playerMask);
        Collider2D hitright = Physics2D.OverlapCircle(transform.position + new Vector3(rightPosition, 0, 0), hitRadius, playerMask);
        Collider2D hitUp = Physics2D.OverlapCircle(transform.position - new Vector3(0, upPosition, 0), hitRadius, playerMask);
        Collider2D hitDown = Physics2D.OverlapCircle(transform.position + new Vector3(0,downPosition, 0), hitRadius, playerMask);
        if(hitleft!=null|| hitright != null || hitUp != null || hitDown != null)
        {
            anim.SetTrigger("Attack");
            pc.TakeHit(damage);
            Debug.Log(" PlayerTake Hit: "+pc.health);
            lastAttackTime = Time.time;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position - new Vector3(leftPosition, 0, 0), hitRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(rightPosition, 0, 0), hitRadius);
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, upPosition, 0), hitRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, downPosition, 0), hitRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hitDistance);
    }
}
