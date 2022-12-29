using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRandomEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private void Start()
    {
        foreach(var enemy in enemies)
            enemy.SetActive(false);

        enemies[Random.Range(0, enemies.Length)].SetActive(true);

    }
}
