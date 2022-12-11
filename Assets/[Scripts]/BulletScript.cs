using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript: MonoBehaviour
{
    [Header("Bullet Properties")]
    [Range(0f, 10f)]
    public int bulletSpeed;
    public float bulletLife;
    public float bulletDamage;
    public Vector2 moveDirection;
    public LayerMask collisionLayerMask;
    public bool player;
    public bool enemy;

    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    private Transform playerTarget;
    [SerializeField]
    private Transform target;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerTarget = GameObject.Find("Player").transform;
        target = GameObject.Find("PlayersTarget").transform;
    }

    void Update()
    {
        if (enemy) // if enemy bullet, Shoot Direction = Player Position
        {
            Vector3 playerDirection = (playerTarget.position - transform.position).normalized;
            moveDirection = playerDirection;
        }
        else // if player bullet, Shoot Direction = Forward
        {
            Vector3 direction = target.position + transform.forward;
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
        if (player) PlayerBulletMove();
        else EnemyBulletMove();
        DestroyByTime();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        playerController.hp -= bulletDamage;
        Debug.Log(playerController.hp);
        Destroy(gameObject);
    }

    public void EnemyBulletMove() //if enemy bullet, Shoot Direction = Player Position
    {
        transform.position += new Vector3(moveDirection.x, moveDirection.y) * bulletSpeed * Time.deltaTime;
    }

    public void PlayerBulletMove() // if player bullet, Shoot Direction = Forward
    {
        transform.position += new Vector3(moveDirection.x, 0.0f) * bulletSpeed * Time.deltaTime;
    }

    public void DestroyByTime()
    {
        Destroy(this.gameObject, bulletLife);
    }
}
