using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyDead : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Collider col;
    [SerializeField] Rigidbody rb;
    [SerializeField] float destroyTime;

    public void EnemyHitted()
    {
        anim.SetTrigger("Damaged");
    }

    public void EnemyKilled()
    {
        gameObject.tag = "Dead"; // send it to TowerTrigger to stop the shooting
        anim.SetTrigger("Dead");
        col.enabled = false;
        rb.isKinematic = true;
        Destroy(agent);
        Destroy(gameObject, destroyTime);
    }
}
