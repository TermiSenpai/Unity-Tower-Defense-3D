using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TorretShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private TargetSearching targetSearching;
    private float cooldown = 0;
    private TurretStats stats;

    private void Start()
    {
        stats = GetComponent<TurretStats>();
        targetSearching = GetComponent<TargetSearching>();
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;

        // If enemy in range, shoot
        if (cooldown <= 0f && targetSearching.HaveTarget())
        {
            Shoot();
            cooldown = 1f / stats.turret.fireRate;
        }


    }

    private void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(stats.turret.bullet, firePoint.position, firePoint.rotation);
        MovementBullets bullet = bulletGo.GetComponent<MovementBullets>();

        if (bullet != null)
        {
            bullet.EnemySeek(targetSearching.GetTarget());

            bullet.BulletDamage(stats.turret.damage);
        }
    }
}
