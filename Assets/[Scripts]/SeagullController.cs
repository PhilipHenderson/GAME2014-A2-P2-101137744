using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullController : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public Transform target;
    public Collider2D gullCollider;
    public float angle;
    public float fireRate = 100;
    public LayerMask collisionLayerMask;

    public bool InAttackRange;
    public bool isDetected;

    public Vector2 ShootingDirection;

    public SeagullPlayerDetection isPlayerDetected;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        gullCollider = GetComponent<Collider2D>();
    }
    // Make and get a seagul Player Detection Script
    void Start()
    {
        InAttackRange = false;
        isDetected = false;
    }

    void Update()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        isDetected = isPlayerDetected.playerDetected;
        InAttackRange = isPlayerDetected.playerInRange;
        if (isDetected)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            bulletSpawnPoint.rotation = rotation;
            ShootingDirection = direction;
            if (InAttackRange)
            {
                FireBullets();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        collider = gullCollider;
        if (collider.gameObject.name == "Player")
        {
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }

    public void FireBullets()
    {
        //Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
