using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] EnemyDead enemyDead;
    [SerializeField] EnemyIncreaseHP increasedHPPerRound;
    private EnemyHealthBar healthBar;
    private EnemyWaveSpawner wave;
    public float startHealth = 5;
    private float health;
    bool isDead = false;
    public bool isPoisoned = false;

    private void Start()
    {
        healthBar = GetComponent<EnemyHealthBar>();
        wave = FindObjectOfType<EnemyWaveSpawner>();        

        if (wave.GetRound() > 1)
            startHealth += (wave.GetRound() * increasedHPPerRound.GetIncreasedHP());

        health = startHealth;
    }

    public void Dmg(int DMGcount)
    {
        health -= DMGcount;
        enemyDead.EnemyHitted();

        healthBar.OnTakeDamage(health / startHealth);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            enemyDead.EnemyKilled();
        }

    }

    public IEnumerator PoisonEnemy(int damage)
    {
        for(int i = 0; i < 5; i++)
        {
            Dmg(damage);
            yield return new WaitForSeconds(1f);
        }
    }

}
