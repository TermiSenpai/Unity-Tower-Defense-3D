using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerCollision : MonoBehaviour
{
    [SerializeField] private CastleHp castle;
    [SerializeField] private int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            // if not dead
            if (!castle.GetIsDead())
                castle.HitCastle(damage);
        }

    }
}
