using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rigid;
    Animator anim;
    public Joystick joystick;
    Vector2 movement;
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        movement = new Vector2();
    }
    private void Update()
    {
        if (Mathf.Abs(joystick.Direction.x) > Mathf.Abs(joystick.Direction.y))
        {
            movement.x = joystick.Direction.x;
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
            movement.y = joystick.Direction.y;
        }
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + movement*moveSpeed*Time.fixedDeltaTime);
    }
}
