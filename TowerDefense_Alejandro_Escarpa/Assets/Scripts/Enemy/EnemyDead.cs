using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyDead : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Rigidbody rb;
    [SerializeField] float destroyTime;

    public void EnemyHitted()
    {
        anim.SetTrigger("Damaged");
    }

    public void EnemyKilled()
    {
        // fix for something i dont know why the enemy enter inside the floor
        // TODO Find the bug and fix without this
        if (transform.position.y < 2)
        {
            Vector3 newpos = new Vector3(transform.position.x, 2, transform.position.z);
            transform.position = newpos;
        }

        rb.isKinematic = true;
        gameObject.tag = "Dead"; // send it to TowerTrigger to stop the shooting
        anim.SetTrigger("Dead");
        agent.enabled = false;
        Destroy(gameObject, destroyTime);
    }
}
