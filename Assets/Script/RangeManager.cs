using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeManager : MonoBehaviour
{
    public Vector3 range_lower;
    public Vector3 range_upper;

    // Start is called before the first frame update
    void Start()
    {
        range_lower = transform.position + Vector3.Scale(transform.localScale, new Vector3(-0.5f, -0.5f, -0.5f));
        range_upper = transform.position + Vector3.Scale(transform.localScale, new Vector3(0.5f, 0.5f, 0.5f));
    }

}
