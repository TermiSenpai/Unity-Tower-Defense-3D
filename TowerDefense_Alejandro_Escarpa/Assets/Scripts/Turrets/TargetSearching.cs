using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetSearching : MonoBehaviour
{
    private TurretStats stats;
    private Transform target;
    private string enemyTag = "Enemy";
    private float updateTime = 0.5f;

    private void Start()
    {
        stats = GetComponent<TurretStats>();
        StartCoroutine(UpdateTarget());
    }

    private IEnumerator UpdateTarget()
    {
        while (true)
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

            if (nearestEnemy != null && shortestDistance <= stats.turret.range)
            {
                target = nearestEnemy.transform;
            }
            else
                target = null;

            yield return new WaitForSeconds(updateTime);
        }
    }

    public bool HaveTarget()
    {
        return target != null;
    }

    public Transform GetTarget()
    {
        return target;
    }
}
