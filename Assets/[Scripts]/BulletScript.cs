using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript: MonoBehaviour
{
    [Header("Bullet Properties")]
    [Range(0f, 10f)]
    public int bulletSpeed;
    public float bulletLife;
    public Vector2 moveDirection;
    public LayerMask collisionLayerMask;
    public bool player;
    public bool enemy;

    private Transform playerTarget;
    private Transform target;

    private void Start()
    {
        playerTarget = GameObject.Find("Player").transform;
        target = GameObject.Find("PlayersTarget").transform;
    }

    void Update()
    {
        if (enemy)
        {
            Vector3 playerDirection = (playerTarget.position - transform.position).normalized;
            moveDirection = playerDirection;
        }
        else
        {
            Vector3 direction = target.position + transform.forward;
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
        if (player) Move2();
        else Move();
        DestroyByTime();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    public void Move()
    {
        transform.position += new Vector3(moveDirection.x, moveDirection.y) * bulletSpeed * Time.deltaTime;
    }

    public void Move2()
    {
        transform.position += new Vector3(moveDirection.x, 0.0f) * bulletSpeed * Time.deltaTime;
    }

    public void DestroyByTime()
    {
        Destroy(this.gameObject, bulletLife);
    }
}
