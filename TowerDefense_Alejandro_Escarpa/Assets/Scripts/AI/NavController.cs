using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    float baseSpeed;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyTarget").GetComponent<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        baseSpeed = agent.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Slow"))
            SlowEnemy(other.gameObject.GetComponent<SlowManager>().GetSlowPercent());
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyBaseSpeed();
    }

    private void SlowEnemy(float percent) => agent.speed *= percent;
    private void EnemyBaseSpeed() => agent.speed = baseSpeed;
}
