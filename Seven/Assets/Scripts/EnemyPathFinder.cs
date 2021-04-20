using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPathFinder : MonoBehaviour
{
    AIPath path;
    PathfinderControl pathfindercontrol;
    Transform player;
    public Animator anim;

    float distance;
    public float sightDistance = 50;
    void Start()
    {
        pathfindercontrol = GameObject.FindGameObjectWithTag("Pathfinding").GetComponent<PathfinderControl>();
        path = GetComponent<AIPath>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void canMove(bool value)
    {
        path.canMove = value;
    }
    private void FixedUpdate()
    {
        distance = (player.position - transform.position).magnitude;
        if (distance > sightDistance)
        {
            path.canMove = false;
            return;
        }
        
        path.canMove = pathfindercontrol.pathFindingActivity;
        if (!path.canMove)
        {
            anim.SetFloat("Speed", 0);
        }
        else if (path.desiredVelocity.magnitude > 0.01f)
        {
            anim.SetFloat("Speed", path.desiredVelocity.magnitude);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightDistance);
    }
}
