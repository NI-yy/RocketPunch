using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryController : MonoBehaviour
{
    public AudioClip clip;
    public GameObject SceneDirector;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            SceneDirector.GetComponent<SceneDirector>().Retry();
        }
    }

    // �Q�[���I�u�W�F�N�g���m���ڐG�����^�C�~���O�Ŏ��s
    void OnTriggerEnter(Collider collider)
    {
        // �����Փ˂�������I�u�W�F�N�g�̖��O��"Punch"�Ȃ��
        if (collider.gameObject.layer == 3)
        {
            //���ʉ��Đ�
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
            //���g���C
            Debug.Log("���g���C�O");
            SceneDirector.GetComponent<SceneDirector>().Retry();
            Debug.Log("���g���C��");
        }
    }
}
