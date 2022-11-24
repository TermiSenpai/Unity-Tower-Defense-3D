using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] EnemyDead enemyDead;
    public int EnemyHP = 30;

    public void Dmg(int DMGcount)
    {
        EnemyHP -= DMGcount;
        enemyDead.EnemyHitted();
    }

    private void Update()
    {

        if (EnemyHP <= 0)
        {
            enemyDead.EnemyKilled();
        }
    }

}
