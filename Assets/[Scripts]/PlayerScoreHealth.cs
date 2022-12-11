using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreHealth : MonoBehaviour
{
    [Header("Health Properties")]
    public float currentHealth;
    public float maxHealth;

    [Header("Score Properties")]
    public float score;

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        currentHealth--;
    }
}
