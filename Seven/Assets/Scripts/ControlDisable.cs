using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisable : MonoBehaviour
{
    Joystick joystick;
    GameObject attackButton;
    PathfinderControl pathfindercontrol;
    GameObject[] skillButtons = new GameObject[3];
    void Start()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        attackButton = GameObject.FindGameObjectWithTag("AttackButton");
        skillButtons[0] = GameObject.FindGameObjectWithTag("Skill1");
        pathfindercontrol = GameObject.FindGameObjectWithTag("Pathfinding").GetComponent<PathfinderControl>();
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
        joystick.gameObject.SetActive(true);
        attackButton.SetActive(true);
        joystick.enabled = true;
        pathfindercontrol.pathFindingActivity = true;
        for (int i = 0; i < 3; i++)
        {
            if (skillButtons[i] != null)
                skillButtons[i].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
