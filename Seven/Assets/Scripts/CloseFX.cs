using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFX : MonoBehaviour
{
    void destroyObject(int value)
    {
        if (value == -1)
        {
            Debug.Log("Reissss");
            Destroy(gameObject);
        }
    }
}
