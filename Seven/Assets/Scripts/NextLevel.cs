using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    ControlDisable cDisable;
    float health, damage;
    public float[] healthValues;
    public float[] attackValues;
    void Start()
    {
        cDisable = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<ControlDisable>();
        health = PlayerPrefs.GetFloat("Health", 200);
        damage = PlayerPrefs.GetFloat("Attack", 25);
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
            if (health < healthValues[level])
            {
                PlayerPrefs.SetFloat("Health", healthValues[level]);
            }
            if(damage< attackValues[level])
            {
                PlayerPrefs.SetFloat("Attack", attackValues[level]);
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
