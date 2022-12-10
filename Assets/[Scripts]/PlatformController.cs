using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("Platform Properties")]
    public float speed = 1.0f;
    public Vector2 direction;
    public bool flying;
    public bool climbing;
    [SerializeField]
    private Vector2 currentPosition;
    public float boundary1;
    public float boundary2;


    private void Start()
    {
        if (flying)
        {
            direction = Vector2.right;
        }
        if (climbing)
        {
            direction = Vector2.up;
        }
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        if (flying)
        {
            if (transform.position.x < boundary1)
            {
                direction.x *= -1.0f;
            }
            if (transform.position.x > boundary2)
            {
                direction.x *= -1.0f;
            }
            Move();
        }

        if (climbing)
        {
            //direction = Vector2.up;
            if (transform.position.y < boundary1)
            {
                direction.y *= -1.0f;
            }
            if (transform.position.y > boundary2)
            {
                direction.y *= -1.0f;
            }
            Move();
        }
    }

    public void Move()
    {
        if(flying) transform.position += new Vector3(direction.x, 0.0f) * speed * Time.deltaTime;
        if(climbing) transform.position += new Vector3(0.0f, direction.y) * speed * Time.deltaTime;
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
