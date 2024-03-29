using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public NPCConversation my_conversation;
    public bool enabled_conv = false;
    [HideInInspector]
    public bool ended = false;
    public string PrefName = "Dungeon Code";
    public bool debug = false;
    ControlDisable cd;
    public TMP_FontAsset font;
    private void Start()
    {
        cd = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<ControlDisable>();
        if (!debug&&PlayerPrefs.GetInt(PrefName,1)!=1)
        {
            ended = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !enabled_conv&&!ended)
        {
            enabled_conv = true;
            my_conversation.DefaultFont = font;
            ConversationManager.Instance.StartConversation(my_conversation);
            ConversationManager.OnConversationEnded = ConversationEnd;

            cd.disableControls();
        }
        
    }
    public void triggerDialogue()
    {
        if (!enabled_conv && !ended)
        {
            Debug.Log("dialog başlatıldı");
            enabled_conv = true;
            my_conversation.DefaultFont = font;
            ConversationManager.Instance.StartConversation(my_conversation);
            ConversationManager.OnConversationEnded = ConversationEnd;  
            cd.disableControls();
        }  
    }
    private void ConversationEnd()
    {
        if(PrefName=="Dungeon 7")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Helmet");
            PlayerPrefs.SetInt(PrefName, 0);
            ended = true;
            this.enabled = false;  
            return;
        }
        cd.enableControls();
        ended = true;
        Debug.Log("A conversation has ended.");
        PlayerPrefs.SetInt(PrefName, 0);
        this.enabled = false;
    }
    private void OnDrawGizmos()
    {
        if (ended)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(this.gameObject.transform.position, new Vector3(this.gameObject.GetComponent<BoxCollider2D>().size.x, this.gameObject.GetComponent<BoxCollider2D>().size.y, 0));
        }
    }
}
