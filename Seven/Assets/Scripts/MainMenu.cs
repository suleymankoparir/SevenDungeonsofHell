using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public TextMeshProUGUI txt;
    public bool debugCon = false;
    MainSoundManager mainSoundManager;
    public Slider slider;
    private void Start()
    {
        mainSoundManager = GameObject.FindGameObjectWithTag("MainSoundManager").GetComponent<MainSoundManager>();
        if(debugCon||PlayerPrefs.GetString("Game","not active")== "not active")
        {
            Color temp = txt.color;
            temp.a = 0.3f;
            txt.color = temp;
            continueButton.interactable=false;
        }
    }
    public void newGame()
    {
        mainSoundManager.Play("Click");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Game", "active");
        SceneManager.LoadScene("DungeonNameTrans");
    }
    public void continueGame()
    {
        mainSoundManager.Play("Click");
        SceneManager.LoadScene("DungeonNameTrans");
    }
    public void exitButton()
    {
        mainSoundManager.Play("Click");
        Application.Quit();
    }
    public void optionButton()
    {
        mainSoundManager.Play("Click");
    }
    public void volumeChange()
    {
        mainSoundManager.changeVolume(slider.value);
        PlayerPrefs.SetFloat("Volume", slider.value);
    }
}
