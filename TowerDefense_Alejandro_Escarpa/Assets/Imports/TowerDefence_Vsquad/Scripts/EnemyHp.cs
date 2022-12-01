using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] EnemyDead enemyDead;
    public int EnemyHP = 30;

    private EnemyWaveSpawner wave;
    private void Start()
    {
        wave = FindObjectOfType<EnemyWaveSpawner>();
        if (wave.GetRound() > 1)
            EnemyHP = Mathf.RoundToInt(EnemyHP + wave.GetRound() * 1.5f);
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
