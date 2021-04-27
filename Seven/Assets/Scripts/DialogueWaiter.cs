using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DialogueWaiter : MonoBehaviour
{
    public DialogueTrigger dTrigger;
    public TargetSetter tSetter;
    void FixedUpdate()
    {
        if (dTrigger.ended)
        {
            tSetter.enabled = true;
            this.enabled = false;
        }
    }
}
