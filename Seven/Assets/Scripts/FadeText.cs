using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    Text txt;
    Color temp;
    public float deltatime=0.5f;
    float lasttime=0;
    public float deltaalpha = 0.1f;
    public float visibleTime = 4f;
    
    void Start()
    {
        txt = GetComponent<Text>();
        temp = txt.color;

    }

    
    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad>visibleTime&&Time.time > lasttime + deltatime)
        {
            lasttime = Time.time;
            temp.a -= deltaalpha;
            txt.color = temp;
            if (temp.a <= 0)
            {
                this.enabled = false;
            }
                
        }
    }
}
