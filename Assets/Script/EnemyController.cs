using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip clip;
    public EnemyGenerator generator;
    public GameObject hitEffect;

    // �Q�[���I�u�W�F�N�g���m���ڐG�����^�C�~���O�Ŏ��s
    void OnTriggerEnter(Collider collider)
    {
        // �����Փ˂�������I�u�W�F�N�g�̖��O��"Cube"�Ȃ��
        if (collider.gameObject.CompareTag("PunchCube"))
        {

            generator.EnemyCount--;
            //���ʉ��Đ�
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
            //�G�t�F�N�g�Đ�
            hitEffect.GetComponent<ParticleSystem>().Play();

            Destroy(this.gameObject);
            
        }
    }

}
