using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFX : MonoBehaviour
{
    void destroyObject(int value)
    {
        if (value == -1)
        {
            Destroy(gameObject);
        }
    }
}
