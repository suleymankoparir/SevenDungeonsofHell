using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public AudioSource clickSound;
    public GameObject MainMenu;
    public GameObject optionTab;
    public void openOption()
    {
        clickSound.Play();
        MainMenu.SetActive(false);
        optionTab.SetActive(true);
    }
    public void closeOption()
    {
        clickSound.Play();
        MainMenu.SetActive(true);
        optionTab.SetActive(false);
    }
}
