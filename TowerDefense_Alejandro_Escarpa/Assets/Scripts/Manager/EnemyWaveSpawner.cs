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
    [SerializeField] private int extraEnemies;
    bool canSpawnEnemies = true;

    private int enemiesInList = 0;
    private List<GameObject> posibleEnemies = new List<GameObject>();

    private void Start()
    {
        round = 1;
        spawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();

        posibleEnemies.Add(enemies[enemiesInList]);
        enemiesInList++;
    }

    public void StartEnemyWave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && canSpawnEnemies)
        {
            StartCoroutine(IEnemyWaveSpawner());
            StartCoroutine(ShowWaveTxt.instance.OnStartWaveBtnPressed());
        }
    }


    IEnumerator IEnemyWaveSpawner()
    {
        canSpawnEnemies = false;
        changeRoundTxt();
        Debug.Log("Wave Incoming!");
        yield return new WaitForSeconds(timeBeforeSpawn);

        for (int i = 0; i < round + 1; i++)
        {
            Instantiate(posibleEnemies[Random.Range(0, posibleEnemies.Count)], spawner.position, Quaternion.identity, parent);
            yield return new WaitForSeconds(timeBetweenEnemies);

        }

        yield return new WaitForSeconds(timeBetweenEnemies * 2f);

        if (round % 10 == 0)
        {
            Instantiate(bosses[Random.Range(0, bosses.Length)], spawner.position, Quaternion.identity, parent);
            extraEnemies += 2;
            increaseAllEnemyHP();
        }

        canSpawnEnemies = true;
        if (GetRound() % 2 == 0)
            AddNewEnemyToList();
        ChangeRound(1);
    }

    private void increaseAllEnemyHP()
    {
        foreach (GameObject enemy in enemies)
        {
            EnemyIncreaseHP enemiesHP = enemy.GetComponent<EnemyIncreaseHP>();

            enemiesHP.IncreaseHP();
        }
    }

    private void AddNewEnemyToList()
    {
        if (enemiesInList >= enemies.Length) return;

        posibleEnemies.Add(enemies[enemiesInList]);
        enemiesInList++;
    }

    public int GetRound() { return round; }

    public void SetRound(int value)
    {
        round = value;
    }

    public void ChangeRound(int value)
    {
        round += value;
    }

    public void changeRoundTxt()
    {
        roundTxt.text = $"Round {round}";
    }

}
