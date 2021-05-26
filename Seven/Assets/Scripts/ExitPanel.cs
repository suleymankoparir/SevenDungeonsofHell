using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    ControlDisable cd;
    DialogueTrigger dTrigger;
    private void Start()
    {
        cd = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<ControlDisable>();
        dTrigger = GameObject.FindGameObjectWithTag("DialogueTrigger").GetComponent<DialogueTrigger>();
    }
    public void continueButton()
    {
        if (dTrigger == null || !dTrigger.enabled_conv || !dTrigger.isActiveAndEnabled)
            cd.enableControls();
        this.gameObject.SetActive(false);
    }
    public void exitButton()
    {
        Application.Quit();
    }
}
