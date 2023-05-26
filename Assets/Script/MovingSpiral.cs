using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpiral : MonoBehaviour
{
    float T = 5.0f;
    float f;
    Vector3 initPos;
    float rand;

    // Start is called before the first frame update
    void Start()
    {
        f = 1.0f / T;
        rand = UnityEngine.Random.Range(-10f, 10f);
        Debug.Log((Mathf.Sin(2 * Mathf.PI * f * (Time.time + rand)), rand));
    }

    // Update is called once per frame
    void Update()
    {
        float sin_x = Mathf.Sin(2 * Mathf.PI * f * (Time.time + rand)) * 18 + 22;
        float cos_x = Mathf.Cos(2 * Mathf.PI * f * (Time.time + rand)) * 18;

        this.transform.position = new Vector3(cos_x, 2.0f, sin_x);
    }
}
