using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        
    }
}
