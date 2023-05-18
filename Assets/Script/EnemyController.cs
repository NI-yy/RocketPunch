using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip clip;
    public EnemyGenerator generator;
    public GameObject hitEffect;
    public bool isBlue;
    public bool isYellow;
    public bool isRed;

    // �Q�[���I�u�W�F�N�g���m���ڐG�����^�C�~���O�Ŏ��s
    void OnTriggerEnter(Collider collider)
    {
        if (isBlue)
        {
            // �����Փ˂�������I�u�W�F�N�g�̖��O��"Cube"�Ȃ��
            if (collider.gameObject.CompareTag("PunchCube") || collider.gameObject.CompareTag("YellowPunch") || collider.gameObject.CompareTag("RedPunch"))
            {
                generator.EnemyCount--;
                //���ʉ��Đ�
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                //�G�t�F�N�g�Đ�
                hitEffect.GetComponent<ParticleSystem>().Play();

                Destroy(this.gameObject);
            }
        }
        
        if (isYellow)
        {
            if (collider.gameObject.CompareTag("YellowPunch") || collider.gameObject.CompareTag("RedPunch"))
            {
                generator.EnemyCount--;
                //���ʉ��Đ�
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                //�G�t�F�N�g�Đ�
                hitEffect.GetComponent<ParticleSystem>().Play();

                Destroy(this.gameObject);
            }
        }
        
        if (isRed)
        {
            if (collider.gameObject.CompareTag("RedPunch"))
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

}
