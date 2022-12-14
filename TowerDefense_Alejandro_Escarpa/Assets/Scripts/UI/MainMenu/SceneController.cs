using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LengthSelect(float value)
    {
        PlayerPrefs.SetFloat("LengthMultiplier", value);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
