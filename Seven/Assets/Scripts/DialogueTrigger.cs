using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueTrigger : MonoBehaviour
{
    public NPCConversation my_conversation;
    bool enabled_conv = false;
    public Joystick joystick;
    public GameObject Control;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !enabled_conv)
        {
            enabled_conv = true;

            ConversationManager.Instance.StartConversation(my_conversation);
            ConversationManager.OnConversationEnded += ConversationEnd;
            joystick.ResetJoystickValues();         
            joystick.enabled = false;
            Control.SetActive(false);
        }
        
    }
    private void ConversationEnd()
    {
        Debug.Log("A conversation has ended.");
        Control.SetActive(true);
        joystick.enabled = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.gameObject.transform.position, new Vector3(this.gameObject.GetComponent<BoxCollider2D>().size.x, this.gameObject.GetComponent<BoxCollider2D>().size.y, 0));
    }
}
