using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffectController : MonoBehaviour
{
    //的が動く場合、エフェクトもそれに追従しなければならないのでそのためのスクリプト
    public GameObject eightSidedBody_Enemy;

    void Start()
    {
        this.transform.position = eightSidedBody_Enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = eightSidedBody_Enemy.transform.position;
    }
}
