using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHp : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private float health;
    [SerializeField] private bool isDead = false;
    [SerializeField] EnemyHealthBar healthbar;

    private void Start()
    {
        health = startHealth;
    }

    public void HitCastle(int damage)
    {
        health -= damage;
        CheckHealth();
        healthbar.OnTakeDamage(health / startHealth);
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            GameOverManager.instance.GameOver();
        }

        Debug.Log($"you have {health} left");
    }

    public bool GetIsDead() { return isDead; }

}
