using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalking : MonoBehaviour
{

    float T = 1.0f;
    float f;
    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        f = 1.0f / T;
        initPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);
        this.transform.position = initPos +  new Vector3(0, sin, 0);
    }
}
