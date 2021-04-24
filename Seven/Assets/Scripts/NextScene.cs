using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public string sceneName = "";
    public FadeText fText;
    void FixedUpdate()
    {
        if (fText.enabled == false)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
