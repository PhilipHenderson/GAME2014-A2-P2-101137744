using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullPlayerDetection : MonoBehaviour
{
    public bool playerDetected;
    public bool playerInRange;
    public bool LOS;
    public Transform playerTransform;
    public Collider2D colliderName;
    public float detectionRadius;
    public float attackRadius;
    public LayerMask collisionLayerMask;
    public LayerMask playerLayerMask;

    void Awake()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    void Start()
    {
        playerDetected = false;
        LOS = false;
    }

    void Update()
    {
        playerDetected = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayerMask);
        playerInRange = Physics2D.OverlapCircle(transform.position, attackRadius, playerLayerMask);

        if (playerDetected)
        {
            var hit = Physics2D.Linecast(transform.position, playerTransform.position, collisionLayerMask);

            colliderName = hit.collider;
            LOS = (colliderName.gameObject.name == "Player");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = (LOS) ? Color.green : Color.red;

        if (playerDetected)
        {
            Gizmos.DrawLine(transform.position, playerTransform.position);
        }

        Gizmos.color = (playerDetected) ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = (playerDetected) ? Color.red : Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
