using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 1.0f;

    [Header("Flying Platform Properties")]
    public bool flying;
    private Vector3 flyVector;

    [Header("Flying Platform Properties")]
    public bool climbing;
    private Vector3 climbVector;

    public void Awake()
    {
        climbVector.y = speed;
        flyVector.x = speed;
    }
    private void Start()
    {
        flying = true;
    }

    void Update()
    {
        if (flying)
        {
            transform.position += flyVector * speed * Time.deltaTime;
        }

        if (climbing)
        {
            transform.position += climbVector * speed * Time.deltaTime;
        }
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(transform);
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(null);
    }
}
