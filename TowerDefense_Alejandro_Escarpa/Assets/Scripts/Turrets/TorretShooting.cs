using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireCountdown;
    [SerializeField] private TurretPivotRotate turretPivotRotate;

    private void Update()
    {
            fireCountdown -= Time.deltaTime;

        // If enemy in range, shoot
        if (fireCountdown <= 0f && turretPivotRotate.HaveTarget())
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
            bullet.EnemySeek(turretPivotRotate.GetTarget());
    }
}
