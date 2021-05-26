using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanelButton : MonoBehaviour
{
    ControlDisable cd;
    public GameObject panel;
    DialogueTrigger dTrigger;
    private void Start()
    {
        cd = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<ControlDisable>();
        dTrigger = GameObject.FindGameObjectWithTag("DialogueTrigger").GetComponent<DialogueTrigger>();

    }
    public void buttonPressed()
    {
        if(dTrigger==null|| !dTrigger.enabled_conv||!dTrigger.isActiveAndEnabled)
             cd.disableControls();
        panel.SetActive(true);
    }
}
