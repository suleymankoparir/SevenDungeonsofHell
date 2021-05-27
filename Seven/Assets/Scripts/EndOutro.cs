using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOutro : MonoBehaviour
{
    public Text[] txt;
    //public string[] texts;
    Color temp;
    public float deltatime = 0.5f;
    float lasttime = 0;
    public float deltaalpha = 0.1f;
    public float visibleTime = 4f;
    int counter = 0;
    void Start()
    {
        temp = txt[0].color;
        temp.a = 0;
        for(int i = 1; i < txt.Length; i++)
        {
            txt[i].color = temp;
        }
        temp.a = 1;
    }


    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > (visibleTime*(counter+1)) && Time.time > lasttime + deltatime)
        {
            lasttime = Time.time;
            temp.a -= deltaalpha;
            txt[counter].color = temp;
            if (temp.a <= 0)
            {
                counter++;
                if (counter == txt.Length)
                {
                    SceneManager.LoadScene("MainMenu");
                    this.enabled = false;
                }
                else
                {
                    temp.a = 1;
                    txt[counter].color = temp;
                }
                
            }
        }
        /*
        if (Time.timeSinceLevelLoad > visibleTime && Time.time > lasttime + deltatime)
        {
            

        }
        */
    }
}
