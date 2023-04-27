using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��������GameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;
    [Tooltip("���x����")]
    public float adjustVelocity;
    [Tooltip("�������x")]
    public float createTime;

    Vector3 EnemyToPalyerVector;

    // �o�ߎ���
    private float time;

    // Update is called once per frame
    void Update()
    {
        // �O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;

        // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
        if (time > createTime)
        {
            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            GameObject EnemyObject = Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
            EnemyToPalyerVector = - EnemyObject.transform.position;
            Rigidbody rb = EnemyObject.GetComponent<Rigidbody>();
            rb.velocity = EnemyToPalyerVector * adjustVelocity;


            // �o�ߎ��ԃ��Z�b�g
            time = 0f;
        }
    }
}
