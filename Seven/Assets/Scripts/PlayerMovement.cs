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
    public float minMovement = 0.3f;
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        movement = new Vector2();
    }
    private void Update()
    {
        if (joystick.isActiveAndEnabled&&(Mathf.Abs(joystick.Direction.x)>minMovement|| Mathf.Abs(joystick.Direction.y)>minMovement))
        {
            movement.x = joystick.Direction.x;
            movement.y = joystick.Direction.y;
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
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
