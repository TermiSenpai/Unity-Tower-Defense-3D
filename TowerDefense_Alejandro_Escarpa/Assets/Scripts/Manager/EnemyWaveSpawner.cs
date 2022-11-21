using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform spawner;
    [SerializeField] Transform parent;
    [SerializeField] float timeBeforeSpawn;
    [SerializeField] float timeBetweenEnemies;
    [SerializeField] int round;
    [SerializeField] int maxRounds;

    private void Start()
    {
        StartCoroutine(IEnemyWaveSpawner());
    }

    


    IEnumerator IEnemyWaveSpawner()
    {
        Debug.Log("Wave Incoming!");
        yield return new WaitForSeconds(timeBeforeSpawn);

        for (int i = 0; i < round + 1; i++)
        {
            Instantiate(enemies[Random.Range(0,enemies.Length)], spawner.position, Quaternion.identity, parent);
            yield return new WaitForSeconds(timeBetweenEnemies);

        }
    }

}
