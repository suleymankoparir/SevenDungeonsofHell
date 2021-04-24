using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetSetter : MonoBehaviour
{
    AIDestinationSetter destinationSetter;
    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = GameObject.FindGameObjectWithTag("Player").transform;
        this.enabled = false;
    }

}
