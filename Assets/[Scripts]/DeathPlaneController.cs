using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeathPlaneController : MonoBehaviour
{
    public Transform currentCheckPoint;
    public Transform deathPlane;
    public float deathPlaneSpeed;

    public void Update()
    {
        Movement();
    }

    private void Movement()
    {
        deathPlane.localPosition = new Vector2(deathPlane.transform.position.x , (deathPlane.transform.position.y + deathPlaneSpeed));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Respawn(other.gameObject);
        }
    }

    public void Respawn(GameObject go)
    {
        go.transform.position = currentCheckPoint.position;
    }


}
