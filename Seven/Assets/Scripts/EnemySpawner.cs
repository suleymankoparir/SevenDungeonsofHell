using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject summoned_enemy;
    public int maxSummon = 20;
    public int summonInOnce = 4;
    public float deltatime = 7f;
    public LayerMask obstacle;
    float lasttime;
    bool inRange = false;
    List<GameObject> enemy;
    BoxCollider2D boxCollider;
    float rangeX, rangeY;
    int liveEnemy = 0;

    void Start()
    {
        lasttime = 0;
        enemy = new List<GameObject>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        rangeX = boxCollider.bounds.size.x;
        rangeY = boxCollider.bounds.size.y;
    }

    bool enemyCapacity()
    {
        liveEnemy = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Enemy>().currentHealth > 0)
            {
                liveEnemy++;
            }
        }
        if (liveEnemy >= maxSummon)
            return false;
        return true;
    }
    void Update()
    {
        if (inRange && Time.time >= lasttime + deltatime&&enemyCapacity())
        {
            lasttime = Time.time;
            for(int i = 0; i < summonInOnce; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-rangeX/2, rangeX/2)+transform.position.x, Random.Range(-rangeY/2, rangeY/2)+transform.position.y,0);
                Collider2D[] spawnWalls = Physics2D.OverlapBoxAll(new Vector2(vec.x, vec.y), new Vector2(2, 2), 0,obstacle);
                if (spawnWalls.Length == 0)
                {
                    Instantiate(summoned_enemy, vec, Quaternion.identity, transform);
                    if (FindObjectOfType<MainSoundManager>() != null)
                        FindObjectOfType<MainSoundManager>().Play("Summon");
                }
                    
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
            inRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inRange = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, this.gameObject.GetComponent<BoxCollider2D>().size);
    }
}
