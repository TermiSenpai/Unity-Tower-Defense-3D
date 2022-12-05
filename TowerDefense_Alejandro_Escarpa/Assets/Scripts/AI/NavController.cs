using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    float baseSpeed;
    bool isRalenticed = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyTarget").GetComponent<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        baseSpeed = agent.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
            SlowEnemy();
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyBaseSpeed();
    }

    private void SlowEnemy() => agent.speed *= 0.8f;
    private void EnemyBaseSpeed() => agent.speed = baseSpeed;
}
