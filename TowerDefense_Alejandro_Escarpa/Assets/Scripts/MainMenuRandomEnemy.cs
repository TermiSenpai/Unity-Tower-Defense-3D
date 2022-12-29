using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRandomEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private void Start()
    {
        enemies[Random.Range(0, enemies.Length)].SetActive(true);
    }
}
