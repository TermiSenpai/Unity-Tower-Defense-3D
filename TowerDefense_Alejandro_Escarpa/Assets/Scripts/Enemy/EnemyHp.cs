using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] EnemyDead enemyDead;
    [SerializeField] EnemyIncreaseHP increasedHPPerRound;
    private EnemyWaveSpawner wave;
    public float EnemyHP = 30;
    bool isDead = false;

    private void Start()
    {
        wave = FindObjectOfType<EnemyWaveSpawner>();
        if (wave.GetRound() > 1)
            EnemyHP += (wave.GetRound() * increasedHPPerRound.GetIncreasedHP());
    }

    public void Dmg(int DMGcount)
    {
        EnemyHP -= DMGcount;
        enemyDead.EnemyHitted();

        if (EnemyHP <= 0 && !isDead)
        {
            isDead = true;
            enemyDead.EnemyKilled();
        }

    }

}
