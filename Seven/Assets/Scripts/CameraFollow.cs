using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    Vector3 pos;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(0, 0, transform.position.z);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        pos.x = player.position.x;
        pos.y = player.position.y;
        pos.z = transform.position.z;
        Camera.main.transform.position = Vector3.Lerp(pos,player.position,moveSpeed*Time.deltaTime);
    }
}
