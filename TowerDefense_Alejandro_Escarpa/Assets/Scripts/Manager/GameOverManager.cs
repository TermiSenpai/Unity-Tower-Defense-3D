
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject Panels;
    

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

    public void HideButtons()
    {
        Panels.SetActive(false);
    }

    public void HideEnemies()
    {
        EnemyWaveSpawner wave = FindObjectOfType<EnemyWaveSpawner>();
        wave.StopAllCoroutines();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies) 
        {
            enemy.SetActive(false);
        }
    }

    public void ResetTimeScale()
    {
        Time.timeScale= 1.0f;
    }

    public void GameOver()
    {
        ShowGameOverMenu();
        HideButtons();
        HideEnemies();
        ResetTimeScale();
    }
}
