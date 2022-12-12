using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] bosses;
    [Space]
    Transform spawner;
    [SerializeField] Transform parent;
    [SerializeField] float timeBeforeSpawn;
    [SerializeField] float timeBetweenEnemies;
    [SerializeField] int round;
    [SerializeField] TextMeshProUGUI roundTxt;
    bool canSpawnEnemies = true;


    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
        
    }

    public void StartEnemyWave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && canSpawnEnemies)
            StartCoroutine(IEnemyWaveSpawner());
    }


    IEnumerator IEnemyWaveSpawner()
    {
        canSpawnEnemies = false;
        roundTxt.text = $"Round {round}";
        Debug.Log("Wave Incoming!");
        yield return new WaitForSeconds(timeBeforeSpawn);

        for (int i = 0; i < round + 1; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawner.position, Quaternion.identity, parent);
            yield return new WaitForSeconds(timeBetweenEnemies);

        }

        if (round % 10 == 0)
            Instantiate(bosses[Random.Range(0,bosses.Length)], spawner.position, Quaternion.identity, parent);

        canSpawnEnemies = true;
        round++;
    }

    public int GetRound() { return round; }

}
