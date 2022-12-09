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
    public Transform target;
    public LayerMask collisionLayerMask;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
    }

    private void FixedUpdate()
    {
        Move();
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, target.position);
    }

    public void DestroyByTime()
    {
        Destroy(this.gameObject, bulletLife);
    }
}
