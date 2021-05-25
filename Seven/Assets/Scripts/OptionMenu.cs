using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    MainSoundManager mainSoundManager;
    private void Start()
    {
        mainSoundManager = GameObject.FindGameObjectWithTag("MainSoundManager").GetComponent<MainSoundManager>();
    }
    public GameObject MainMenu;
    public GameObject optionTab;
    public void openOption()
    {
        mainSoundManager.Play("Click");
        MainMenu.SetActive(false);
        optionTab.SetActive(true);
    }
    public void closeOption()
    {
        mainSoundManager.Play("Click");
        MainMenu.SetActive(true);
        optionTab.SetActive(false);
    }
}
