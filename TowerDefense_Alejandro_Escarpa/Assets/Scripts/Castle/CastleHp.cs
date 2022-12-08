using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHp : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isDead = false;

    public void HitCastle(int damage)
    {
        health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            GameOverManager.instance.ShowGameOverMenu();
        }

        Debug.Log($"you have {health} left");
    }

    public bool GetIsDead() { return isDead; }

}
