using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    int speed;


    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.0f, speed * Time.deltaTime);
    }
}
