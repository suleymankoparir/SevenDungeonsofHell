using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DungeonName : MonoBehaviour
{
    public Text txt;
    public FadeText fText;
    public string[] names = new string[7];
    void Start()
    {
        txt.text = names[PlayerPrefs.GetInt("Level", 1) - 1];
    }
    private void FixedUpdate()
    {
        if (fText.enabled == false)
        {
            loadLevel();
        }
    }
    public void loadLevel()
    {
        switch(PlayerPrefs.GetInt("Level", 1))
        {
            case 1: SceneManager.LoadScene("Dungeon_1"); break;
            case 2: SceneManager.LoadScene("Dungeon_2"); break;
            case 3: SceneManager.LoadScene("Dungeon_3"); break;
            case 4: SceneManager.LoadScene("Dungeon_4"); break;
            case 5: SceneManager.LoadScene("Dungeon_5"); break;
            case 6: SceneManager.LoadScene("Dungeon_6"); break;
            case 7: SceneManager.LoadScene("Dungeon_7"); break;
        }
    }
}
