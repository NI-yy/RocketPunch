using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffectController : MonoBehaviour
{
    //�I�������ꍇ�A�G�t�F�N�g������ɒǏ]���Ȃ���΂Ȃ�Ȃ��̂ł��̂��߂̃X�N���v�g
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
