using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HawkController : MonoBehaviour
{
    [Header("Movement Propertries")]
    public Transform target;
    public float movementSpeed;
    
    public Vector2 moveDirection;
    
    public bool isDetected;
    
    public HawkPlayerDetection isPlayerDetected;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        isDetected = false;
    }


    void Update()
    {
        isDetected = isPlayerDetected.playerDetected;
        if (isDetected)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
        if (isDetected)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position += new Vector3(moveDirection.x * Time.deltaTime, moveDirection.y * Time.deltaTime, 0.0f) * movementSpeed;
    }

    private void OnDrawGizmos()
    {   
        // KillBox
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
