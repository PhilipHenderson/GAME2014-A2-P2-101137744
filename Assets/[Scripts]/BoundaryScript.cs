using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoundaryScript : MonoBehaviour
{
    public float minBound;
    public float maxBound;

    public void Boundaries(float min, float max)
    {
        minBound = min;
        maxBound = max;
    }
}
