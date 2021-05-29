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
    public bool walkSound = true;
    public bool sawPlayer = false;
    float distance;
    public float sightDistance = 50;
    bool _stunned = false;
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
    public void enableStun()
    {
        _stunned = true;
        path.canMove=false;
    }
    public void disableStun()
    {
        _stunned = false;
    }
    float walksoundLastTime = 0;
    private void FixedUpdate()
    {
        distance = (player.position - transform.position).magnitude;
        if (distance > sightDistance)
        {
            path.canMove = false;
            anim.SetFloat("Speed", 0);
            return;
        }
        else
        {
            sawPlayer = true;
        }
        if(!_stunned)
            path.canMove = pathfindercontrol.pathFindingActivity;
        if (!path.canMove)
        {
            anim.SetFloat("Speed", 0);
        }
        else if (path.desiredVelocity.magnitude > 0.01f)
        {
            if (Time.time > walksoundLastTime + 0.5f)
            {
                walksoundLastTime = Time.time;
                if (FindObjectOfType<MainSoundManager>() != null&&walkSound)
                    FindObjectOfType<MainSoundManager>().PlayWalk("Walk");
            }
            anim.SetFloat("Speed", path.desiredVelocity.magnitude);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightDistance);
    }
}
