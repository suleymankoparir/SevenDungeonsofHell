using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightofPride : MonoBehaviour
{
    public Button button;
    public float deltatime = 5f;
    float lasttime = 0;

    float skillDistance = 8f;
    public float damage = 40f;
    public LayerMask enemyLayer;
    public GameObject lightObject;
    public bool debug = false;
    private void Start()
    {
        if (!debug&&PlayerPrefs.GetInt("Light", -1) == -1)
        {
            button.interactable = false;
            //button.enabled = false;
            this.enabled = false;
        }
    }
    public void hitEnemy()
    {
        Collider2D[] hitArea = Physics2D.OverlapCircleAll(transform.position, skillDistance, enemyLayer);
        if (hitArea.Length > 0)
        {
            if(FindObjectOfType<MainSoundManager>()!=null)
                FindObjectOfType<MainSoundManager>().Play("LightofPride");
        }
        
        for(int i = 0; i < hitArea.Length; i++)
        {
            button.interactable = false;
            lasttime = Time.time;
            Vector3 vec = hitArea[i].gameObject.transform.position;
            vec.y +=2;
            Instantiate(lightObject, vec, Quaternion.identity, hitArea[i].gameObject.transform);
            hitArea[i].gameObject.GetComponent<Enemy>().takeDamage(damage);
            Debug.Log(hitArea[i].gameObject.name + " " + hitArea[i].gameObject.GetComponent<Enemy>().currentHealth);
        }
    }
    private void FixedUpdate()
    {
        if (!button.IsInteractable() && Time.time > lasttime + deltatime)
        {
            button.interactable = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, skillDistance);
    }
}
