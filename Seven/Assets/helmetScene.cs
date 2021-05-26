using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmetScene : MonoBehaviour
{
    public DialogueTrigger dt;
    public void triggerFinalDialogue()
    {
        dt.triggerDialogue();
        Debug.Log("Tetikledim");
    }
}
