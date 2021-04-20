using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightofPride : MonoBehaviour
{

    float skillDistance = 8f;
    public float damage = 40f;
    public LayerMask enemyLayer;
    public GameObject lightObject;
    public void hitEnemy()
    {
        Collider2D[] hitArea = Physics2D.OverlapCircleAll(transform.position, skillDistance, enemyLayer);
        for(int i = 0; i < hitArea.Length; i++)
        {
            Vector3 vec = hitArea[i].gameObject.transform.position;
            vec.y +=2;
            Instantiate(lightObject, vec, Quaternion.identity, hitArea[i].gameObject.transform);
            hitArea[i].gameObject.GetComponent<Enemy>().takeDamage(damage);
            Debug.Log(hitArea[i].gameObject.name + " " + hitArea[i].gameObject.GetComponent<Enemy>().currentHealth);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, skillDistance);
    }
}
