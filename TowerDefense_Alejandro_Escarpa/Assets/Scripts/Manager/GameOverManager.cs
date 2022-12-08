
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    [SerializeField] private GameObject gameOverMenu;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one game over manager in scene");
        }
        instance = this;
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
