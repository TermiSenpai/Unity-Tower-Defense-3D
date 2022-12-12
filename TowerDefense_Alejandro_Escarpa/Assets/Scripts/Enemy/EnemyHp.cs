using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] EnemyDead enemyDead;
    public int EnemyHP = 30;
    [SerializeField] private int hpIncreasePerRound = 1;

    private EnemyWaveSpawner wave;
    private void Start()
    {
        wave = FindObjectOfType<EnemyWaveSpawner>();
        if (wave.GetRound() > 1)
            EnemyHP = EnemyHP + (wave.GetRound() * hpIncreasePerRound);
    }

    public void Dmg(int DMGcount)
    {
        EnemyHP -= DMGcount;
        enemyDead.EnemyHitted();

        if (EnemyHP <= 0)
        {
            enemyDead.EnemyKilled();
        }

    }

}
