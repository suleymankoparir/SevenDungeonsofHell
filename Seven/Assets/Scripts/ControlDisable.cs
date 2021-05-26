using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDisable : MonoBehaviour
{
    public Joystick joystick;
    public GameObject attackButton;
    PathfinderControl pathfindercontrol;
    public GameObject[] skillButtons = new GameObject[3];
    PlayerCombat pCombat;
    void Start()
    {
        Debug.Log("Start");
        //joystick = joyObject.GetComponent<Joystick>();
        //attackButton = GameObject.FindGameObjectWithTag("AttackButton");
        //skillButtons[0] = GameObject.FindGameObjectWithTag("Skill1");
        //skillButtons[1] = GameObject.FindGameObjectWithTag("Skill2");
        //skillButtons[2] = GameObject.FindGameObjectWithTag("Skill3");
        pathfindercontrol = GameObject.FindGameObjectWithTag("Pathfinding").GetComponent<PathfinderControl>();
        pCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }
    public void disableControls()
    {
        joystick.ResetJoystickValues();
        joystick.enabled = false;
        joystick.gameObject.SetActive(false);
        attackButton.SetActive(false);
        pathfindercontrol.pathFindingActivity = false;
        for(int i = 0; i < 3; i++)
        {
            if (skillButtons[i] != null)
            {
                skillButtons[i].SetActive(false);
            }           
        }
    }
    public void enableControls()
    {
        if (pCombat.currentHealth > 0)
        {
            joystick.gameObject.SetActive(true);
            joystick.enabled = true;
            attackButton.SetActive(true);
            pathfindercontrol.pathFindingActivity = true;
            for (int i = 0; i < 3; i++)
            {
                if (skillButtons[i] != null)
                    skillButtons[i].SetActive(true);
            }
        }      
    }
}
