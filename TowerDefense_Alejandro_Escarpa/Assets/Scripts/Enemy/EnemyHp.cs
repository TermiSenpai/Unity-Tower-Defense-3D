using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] EnemyDead enemyDead;
    public int EnemyHP = 30;
    [SerializeField, Range(1f, 5f)] private float hpMultiply = 1.5f;

    private EnemyWaveSpawner wave;
    private void Start()
    {
        wave = FindObjectOfType<EnemyWaveSpawner>();
        if (wave.GetRound() > 1)
            EnemyHP = Mathf.RoundToInt(EnemyHP + wave.GetRound() * hpMultiply);
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
