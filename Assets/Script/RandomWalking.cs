using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class RandomWalking : MonoBehaviour
{

    float T = 10.0f;
    float f;
    Vector3 initPos;
    float rand;

    // Start is called before the first frame update
    void Start()
    {
        f = 1.0f / T;
        initPos = this.transform.position;
        rand = UnityEngine.Random.Range(-1000, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        float sin_x = Mathf.Sin(2 * Mathf.PI * f * (Time.time + rand)) * 3;
        float sin_y = Mathf.Sin(2 * Mathf.PI * f * (Time.time + rand)) * 0.5f;
        float noise = Unity.Mathematics.noise.snoise(new float2(rand, Time.time));
        this.transform.position = initPos +  new Vector3(sin_x + noise, sin_y, 0);
    }

}
