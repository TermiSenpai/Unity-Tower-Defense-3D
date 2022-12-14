using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetSearching : MonoBehaviour
{
    private Transform target;
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private float range = 6;
    private float updateTime = 0.5f;

    private void Start()
    {
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

            if (nearestEnemy != null && shortestDistance <= range)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
