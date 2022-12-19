using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] EnemyDead enemyDead;
    [SerializeField] EnemyIncreaseHP increasedHPPerRound;
    private EnemyWaveSpawner wave;
    public int EnemyHP = 30;

    private void Start()
    {
        wave = FindObjectOfType<EnemyWaveSpawner>();
        EnemyHP += (wave.GetRound() * increasedHPPerRound.GetIncreasedHP());
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
