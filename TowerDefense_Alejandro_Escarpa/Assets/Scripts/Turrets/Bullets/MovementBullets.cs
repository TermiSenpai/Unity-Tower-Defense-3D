using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBullets : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target;
    Vector3 lastBulletPosition;

    void Update()
    {
        // Bullet move

        if (target)
        {

            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            lastBulletPosition = target.transform.position;

        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, lastBulletPosition, Time.deltaTime * speed);

            if (transform.position == lastBulletPosition)
            {
                Destroy(gameObject);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy hit");
        Destroy(gameObject);        
    }

    public void EnemySeek(Transform target)
    {
        this.target = target;
    }
}
