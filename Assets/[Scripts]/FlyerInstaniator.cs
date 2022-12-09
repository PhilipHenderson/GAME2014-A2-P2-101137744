using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerInstaniator : MonoBehaviour
{
    [SerializeField]
    public GameObject flyerPrefab;

    private float leftBoundary;

    void Awake()
    {
        flyerPrefab = GetComponent<GameObject>();
    }

    void Start()
    {
        leftBoundary = -4.0f;
        StartCoroutine(TimedSpawn());
    }
        
    public IEnumerator TimedSpawn()
    {
        yield return new WaitForSeconds(5);
        var position = new Vector2(leftBoundary, Random.Range(10.0f, 100.0f));
        Instantiate(flyerPrefab, position, Quaternion.identity);
    }
}
