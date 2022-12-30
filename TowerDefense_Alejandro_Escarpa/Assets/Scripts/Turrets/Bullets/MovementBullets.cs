using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum bulletEffect
{
    damage,
    poison
}


public class MovementBullets : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private ParticleSystem hitParticle;
    private int damage;
    private Transform target;
    Vector3 lastBulletPosition;
    FBxPlayerManager fbxPlayer;
    [SerializeField] private bulletEffect effect;


    private void Start()
    {
        fbxPlayer = FindObjectOfType<FBxPlayerManager>();
    }

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
        if (other.gameObject.TryGetComponent<EnemyHp>(out EnemyHp enemyHP))
        {
            switch (effect)
            {
                case bulletEffect.damage:
                    enemyHP.Dmg(damage);
                    break;

                case bulletEffect.poison:
                    if (enemyHP.isPoisoned) break;
                    enemyHP.StartCoroutine(enemyHP.PoisonEnemy(damage));
                    break;
            }
        }
        fbxPlayer.ImpactFbxPlay(hitParticle, other.transform);
        Destroy(gameObject);
    }

    public void EnemySeek(Transform target)
    {
        this.target = target;
    }

    public void BulletDamage(int damage)
    {
        this.damage = damage;
    }
}
