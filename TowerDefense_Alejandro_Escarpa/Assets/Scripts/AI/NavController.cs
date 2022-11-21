using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{
    Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyTarget").GetComponent<Transform>();
        NavMeshAgent agent =gameObject.GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }
}
