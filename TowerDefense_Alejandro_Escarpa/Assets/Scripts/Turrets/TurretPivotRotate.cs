using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPivotRotate : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range;
    [SerializeField] private string enemyTag;
    [SerializeField] private Transform partToRotate;
    [SerializeField] private float rotateTime;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
            return;
        ChangeRotateDir();
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanteToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanteToEnemy < shortestDistance)
            {
                shortestDistance = distanteToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
            target = null;
    }

    private void ChangeRotateDir()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public bool HaveTarget()
    {
        return target != null;
    }

    public Transform GetTarget()
    {
        return target;
    }

    public float GetTurretRange() { return range; }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
