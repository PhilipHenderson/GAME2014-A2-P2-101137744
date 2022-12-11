using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    public LayerMask collisionLayerMask;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        playerController.score++;
        Destroy(gameObject);
    }
}
