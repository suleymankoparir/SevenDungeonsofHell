using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    ControlDisable cDisable;
    void Start()
    {
        cDisable = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlDisable>();
    }
    IEnumerator nextLevelIE()
    {
        cDisable.disableControls();
        yield return new WaitForSeconds(5);
        int level = PlayerPrefs.GetInt("Level", 1);
        if (level != 7)
        {
            if (level == 1)
            {
                PlayerPrefs.SetInt("Stun", 1);
            }
            if (level == 2)
            {
                PlayerPrefs.SetInt("Hammer", 1);
            }
            if (level == 6)
            {
                PlayerPrefs.SetInt("Light", 1);
            }
            level += 1;
            PlayerPrefs.SetInt("Level", level);
            SceneManager.LoadScene("DungeonNameTrans");
        }
        else
        {
            PlayerPrefs.SetString("Game", "not active");
            SceneManager.LoadScene("End");
        }
    }
    public void nextLevel()
    {
        StartCoroutine(nextLevelIE());
    }
}
