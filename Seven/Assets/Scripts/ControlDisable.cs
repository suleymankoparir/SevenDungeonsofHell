using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisable : MonoBehaviour
{
    public Joystick joystick;
    public GameObject attackButton;
    PathfinderControl pathfindercontrol;
    public GameObject[] skillButtons = new GameObject[3];
    void Start()
    {
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