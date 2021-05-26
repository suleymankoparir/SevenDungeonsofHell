using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveController : MonoBehaviour
{
    public GameObject objective;
    public GameObject parent;
    public NextLevel nextLevel;
    List<Text> groupTexts=new List<Text>();
    List<Text> killTexts = new List<Text>();
    Text killAllText;
    bool allAchived = false;
    ObjectiveKillAll objectiveKillAll;
    public ObjectiveKill[] objectiveKill;
    public ObjectiveKillGroup[] objectiveKillGroup;
    private void Start()
    {
        if (GetComponent<ObjectiveKillAll>() != null)
        {
            objectiveKillAll = GetComponent<ObjectiveKillAll>();
        }
        if (objectiveKillAll != null)
        {
            killAllText = Instantiate(objective, parent.transform).GetComponent<Text>();
            killAllText.text = objectiveKillAll.objectiveText + " " + objectiveKillAll.aliveEnemy();
        }
        for (int i = 0; i < objectiveKill.Length; i++)
        {
            killTexts.Add(Instantiate(objective, parent.transform).GetComponent<Text>());
            killTexts[i].text = objectiveKill[i].objectiveText;
        }
        for (int i = 0; i < objectiveKillGroup.Length; i++)
        {
            groupTexts.Add(Instantiate(objective, parent.transform).GetComponent<Text>());
            groupTexts[i].text = objectiveKillGroup[i].objectiveText +" "+ objectiveKillGroup[i].aliveEnemy().ToString();
        }    
    }
    void FixedUpdate()
    {
        allAchived = true;
        if (objectiveKillAll != null)
        {
            if (objectiveKillAll.achieved)
            {
                killAllText.text = objectiveKillAll.objectiveText + ": Done";
            }
            else
            {
                killAllText.text = objectiveKillAll.objectiveText + " " + objectiveKillAll.aliveEnemy();
                allAchived = false;
            }         
        }
        for (int i = 0; i < objectiveKill.Length; i++)
        {
            if (objectiveKill[i].achieved)
            {
                killTexts[i].text = objectiveKill[i].objectiveText+ ": Done";
            }
            else
            {
                allAchived = false;
            }
        }
        for (int i = 0; i < objectiveKillGroup.Length; i++)
        {
            if (objectiveKillGroup[i].achieved)
            {
                groupTexts[i].text = objectiveKillGroup[i].objectiveText + ": Done ";
            }
            else
            {
                groupTexts[i].text = objectiveKillGroup[i].objectiveText + " " + objectiveKillGroup[i].aliveEnemy().ToString();
                allAchived = false;
            }
        }
        if (allAchived)
        {
            nextLevel.nextLevel();
            this.enabled = false;
        }
    }
}
