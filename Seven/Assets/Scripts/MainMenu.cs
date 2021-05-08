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
    public AudioSource aSource;
    public Slider slider;
    public AudioSource click;
    private void Start()
    {
        click.volume = PlayerPrefs.GetFloat("Volume", 0.5f);
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
        click.Play();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Game", "active");
        SceneManager.LoadScene("DungeonNameTrans");
    }
    public void continueGame()
    {
        click.Play();
        SceneManager.LoadScene("DungeonNameTrans");
    }
    public void exitButton()
    {
        click.Play();
        Application.Quit();
    }
    public void optionButton()
    {
        click.Play();
    }
    public void volumeChange()
    {
        aSource.volume = slider.value;
        click.volume = slider.value;
        PlayerPrefs.SetFloat("Volume", slider.value);
    }
}
