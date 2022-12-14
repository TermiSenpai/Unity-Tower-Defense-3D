using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TorretShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int bulletDamage;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireCountdown;
    private TargetSearching targetSearching;

    private void Start()
    {
        targetSearching = GetComponent<TargetSearching>();
    }

    private void Update()
    {
        fireCountdown -= Time.deltaTime;

        // If enemy in range, shoot
        if (fireCountdown <= 0f && targetSearching.HaveTarget())
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }


    }

    private void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        MovementBullets bullet = bulletGo.GetComponent<MovementBullets>();

        if (bullet != null)
        {
            bullet.EnemySeek(targetSearching.GetTarget());

            bullet.BulletDamage(bulletDamage);
        }
    }
}
