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
    private void Start()
    {
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
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Game", "active");
        SceneManager.LoadScene("DungeonNameTrans");
    }
    public void continueGame()
    {
        SceneManager.LoadScene("DungeonNameTrans");
    }
}
